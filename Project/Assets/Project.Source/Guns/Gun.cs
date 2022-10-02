using System;
using System.Collections;
using System.Collections.Generic;
using Project.Source;
using Project.Source.Characters;
using UnityEngine;

public enum GunHoldType{
    OneHand
}

public class Gun : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform model;
    [SerializeField] private Transform firePoint;
    [SerializeField] private List<Projectile> projectilePrefabs = new List<Projectile>();

    [Header("Settings")]
    public GunHoldType GunHoldType = GunHoldType.OneHand;
    public float TimeToHolsterGun = 4f;
    public bool ReloadOnSwitchTo = false;
    public int SelectedProjectile = 0;
    public int Burst = 1;
    public float TimeBetweenShots = 1f;
    public int MaxAmmo = 1;
    public float ReloadTime = 2f;

    private float elapsedTimeSinceHolstered = 0f;
    private float elapsedTimeSinceShot = 0f;
    private float elapsedReloadTime = 0f;
    private int ammo = 0;
    private bool isReloading = false;

    private void Awake()
    {
        Reload();
    }
    
    private void Update()
    {
        elapsedTimeSinceShot += Time.deltaTime;
        elapsedTimeSinceShot = Mathf.Clamp(elapsedTimeSinceShot, 0, TimeBetweenShots);
        elapsedTimeSinceHolstered += Time.deltaTime;
        elapsedTimeSinceHolstered = Mathf.Clamp(elapsedTimeSinceHolstered, 0, TimeToHolsterGun);
        
        if (isReloading && elapsedReloadTime >= ReloadTime)
        {
            Reload();
        }
        else if(ammo == 0)
        {
            isReloading = true;
            elapsedReloadTime += Time.deltaTime;
        }
    }

    public void Fire(Character characterFrom)
    {
        if (elapsedTimeSinceShot < TimeBetweenShots || isReloading) return;

        Vector3 direction = firePoint.forward;
        
        for (int i = 0; i < Burst; i++)
        {
            if (ammo == 0) return;

            Projectile projectile = Instantiate(projectilePrefabs[SelectedProjectile], firePoint.position, Quaternion.Euler(firePoint.forward));
            projectile.Fire(characterFrom, direction);
            
            ammo--;
        }

        elapsedTimeSinceShot -= TimeBetweenShots;
        elapsedTimeSinceHolstered = 0;
    }

    public void OnSwitch()
    {
        if(ReloadOnSwitchTo)
            Reload();
    }

    public bool IsFiring()
    {
        return elapsedTimeSinceShot < TimeBetweenShots;
    }

    //For animation purposes
    public bool IsHolstered()
    {
        return elapsedTimeSinceHolstered >= TimeToHolsterGun;
    }

    public Transform GetModel()
    {
        return model;
    }

    private void Reload()
    {
        ammo = MaxAmmo;
        isReloading = false;
        elapsedReloadTime = 0;
        elapsedTimeSinceShot = TimeBetweenShots;
        elapsedTimeSinceHolstered = TimeToHolsterGun;
    }

    private void OnValidate()
    {
        SelectedProjectile = Mathf.Clamp(SelectedProjectile, 0, projectilePrefabs.Count - 1);
        MaxAmmo = Mathf.Clamp(MaxAmmo, Burst, 100); //Arbitrary max
    }
}