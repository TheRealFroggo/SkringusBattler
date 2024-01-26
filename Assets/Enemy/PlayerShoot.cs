using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] GameObject playerBulletPrefab;
    [SerializeField] float BaseDamage;
    [SerializeField] float BaseFireRate;
    [SerializeField] float BaseProjectileSize;
    [SerializeField] float BaseProjectileSpeed;
    [SerializeField] int BaseProjectilePierce;
    [SerializeField] int BaseProjectileCount;
    [SerializeField] float BaseProjectileLifeSpan;

    [Header("Current Stats")]
    [SerializeField] float CurrentDamage;
    [SerializeField] float CurrentFireRate;
    [SerializeField] float CurrentProjectileSize;
    [SerializeField] float CurrentProjectileSpeed;
    [SerializeField] int CurrentProjectilePierce;
    [SerializeField] int CurrentProjectileCount;
    [SerializeField] float CurrentProjectileLifeSpan;
    private float _nextFire = 0;

    void Awake()
    {
        CurrentDamage = BaseDamage;
        CurrentFireRate = BaseFireRate;
        CurrentProjectileSize = BaseProjectileSize;
        CurrentProjectileSpeed = BaseProjectileSpeed;
        CurrentProjectilePierce = BaseProjectilePierce;
        CurrentProjectileCount = BaseProjectileCount;
        CurrentProjectileLifeSpan = BaseProjectileLifeSpan;
    }
    void Update()
    {
        ShootProjectile();
    }

    void ShootProjectile()
    {
        if (!Input.GetMouseButton(0) || !(_nextFire < Time.time)) return;
        GameObject newProj = Instantiate(playerBulletPrefab, transform.position, Quaternion.identity);
        _nextFire = 1.0f/CurrentFireRate + Time.time;

        PlayerBulletMove move = newProj.GetComponent<PlayerBulletMove>();
        if (move != null)
        {
            move.SetSize(CurrentProjectileSize);
            move.SetSpeed(CurrentProjectileSpeed);
            move.SetLifeSpan(CurrentProjectileLifeSpan);
        }

        Damage dmg = newProj.GetComponent<Damage>();
        if (dmg != null)
        {
            dmg.SetNewDamage(CurrentDamage);
            dmg.SetNewPierce(CurrentProjectilePierce);
        }
    }

    public float GetBaseDamage()
    {
        return BaseDamage;
    }

    public void SetNewDamage(float i)
    {
        CurrentDamage = i;
        Debug.Log("New Damage: " + CurrentDamage);
    }

    public float GetBaseFireRate()
    {
        return BaseFireRate;
    }

    public void SetNewFireRate(float i)
    {
        CurrentFireRate = i;
        Debug.Log("New FireRate: " + CurrentFireRate);
    }

    public float GetBaseProjectileSize()
    {
        return BaseProjectileSize;
    }

    public void SetNewProjectileSize(float i)
    {
        CurrentProjectileSize = i;
        Debug.Log("New Proj Size: " + CurrentProjectileSize);
    }

    public float GetBaseProjectileSpeed()
    {
        return BaseProjectileSpeed;
    }

    public void SetNewProjectileSpeed(float i)
    {
        CurrentProjectileSpeed = i;
        Debug.Log("New Proj Speed: " + CurrentProjectileSpeed);
    }

    public int GetBaseProjectilePierce()
    {
        return BaseProjectilePierce;
    }

    public void SetNewProjectilePierce(float i)
    {
        CurrentProjectilePierce = (int)i;
        Debug.Log("New Proj Pierce: " + CurrentProjectilePierce);
    }

    public int GetBaseProjectileCount()
    {
        return BaseProjectileCount;
    }

    public void SetNewProjectileCount(float i)
    {
        CurrentProjectileCount = (int)i;
        Debug.Log("New Proj Count: " + CurrentProjectileCount);
    }

    public float GetBaseProjectileLifeSpan()
    {
        return BaseProjectileLifeSpan;
    }

    public void SetNewProjectileLifeSpan(float i)
    {
        CurrentProjectileLifeSpan = i;
        Debug.Log("New Proj LifeSpan: " + CurrentProjectileLifeSpan);
    }
}
