using Project.Source.Gameplay.Characters;
using UniDi;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

namespace Project.Source.Gameplay.Guns.Projectile
{
    public class SoulTransferProjectile : LineProjectile
    {
        [Header("Soul Transfer Specific")]
        [SerializeField] private VisualEffect vfxPrefab;

        private static readonly ExposedProperty PlayerVelocityAttribute = "Player Velocity";

        [Inject]
        private GameContext gameContext;
    
        public override void Hit(Character character)
        {
            if (character.IsDead) return;

            gameContext.Possess(character);
        }
    
        public override void CreateVisual(Vector3 startPosition, Vector3 endPosition, float distance, Vector3 direction)
        {
            var vfx = Instantiate(vfxPrefab, startPosition, Quaternion.identity);
            vfx.transform.up = direction;
            vfx.SetVector3(PlayerVelocityAttribute, new Vector3(0, -distance,0));

            spawned = vfx.gameObject;
        }
    }
}