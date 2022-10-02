using System;
using System.Collections.Generic;
using Exanite.Core.Events;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.VFX;

namespace Project.Source.Characters
{
    public class Character : MonoBehaviour
    {
        public bool IsPlayer => this == GameContext.Instance.CurrentPlayer;

        [Header("Dependencies")]
        public Rigidbody Rigidbody;
        
        [Header("Configuration")]
        [SerializeField]
        [FormerlySerializedAs("CurrentHealth")]
        private float currentHealth = 100;
        public float MaxHealth = 100;

        [Header("Configuration")]
        public float HealthRegenPerSecond;
        public GunPosition GunPosition;
        public Transform PlayerWickPosition;
        
        [Header("Runtime")]
        public bool IsDead;
        public bool IsDodging;
        public bool IsInvulnerable;
        
        [Header("On Death")]
        public List<Behaviour> DisableOnDeathBehaviours = new List<Behaviour>();
        public List<Collider> DisableOnDeathColliders = new List<Collider>();
        public float OnDeathDestroyDelay = 3f;

        public float CurrentHealth
        {
            get => currentHealth;
            private set => currentHealth = value;
        }

        public event Action<Character> Dead;
        public event EventHandler<Character, float> TookDamage;

        private VisualEffect playerWick;

        private void Update()
        {
            if (IsDead)
            {
                return;
            }

            UpdateHealthDecay();
            CheckDeath();

            UpdatePlayerWick();
        }

        public void TakeDamage(float damageAmount)
        {
            CurrentHealth -= damageAmount;
            
            TookDamage?.Invoke(this, damageAmount);
        }

        public void OverwriteHealth(float value)
        {
            CurrentHealth = value;
        }

        private void UpdateHealthDecay()
        {
            CurrentHealth += Time.deltaTime * HealthRegenPerSecond;
        }
        
        private void UpdatePlayerWick()
        {
            if (IsPlayer)
            {
                if (!playerWick)
                {
                    playerWick = Instantiate(GameContext.Instance.PlayerWickPrefab);
                }

                playerWick.transform.position = PlayerWickPosition.transform.position;

                // Todo Set wick velocity
            }
            else
            {
                Destroy(playerWick);
                playerWick = null;
            }
        }
        
        private void CheckDeath()
        {
            if (CurrentHealth <= 0)
            {
                OnDead();
            }
        }

        protected virtual void OnDead()
        {
            IsDead = true;

            Debug.Log($"{name} died");
            
            foreach (var behaviour in DisableOnDeathBehaviours)
            {
                behaviour.enabled = false;
            }
            
            foreach (var collider in DisableOnDeathColliders)
            {
                collider.enabled = false;
            }

            Destroy(gameObject, OnDeathDestroyDelay);

            Dead?.Invoke(this);
        }
    }
}