using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float BaseAttackDamage;
    [SerializeField] float BaseClickDamage;
    [SerializeField] float BaseProjectileDamage;
    [SerializeField] float BaseBeamDamage;
    [SerializeField] float BaseAuraDamage;

    float AttackDamage;
    float ClickDamage;
    float ProjectileDamage;
    float BeamDamage;
    float AuraDamage;

    public float GetBaseAttack()
    {
        return BaseAttackDamage;
    }

    public void SetNewAttack(float i)
    {
        AttackDamage = i;
        Debug.Log("New Attack Damage: " + AttackDamage);
    }

    public float GetBaseClickAttack()
    {
        return BaseClickDamage;
    }

    public void SetNewClickAttack(float i)
    {
        ClickDamage = i;
        Debug.Log("New Click Attack Damage: " + ClickDamage);
    }

    public float GetBaseProjectileAttack()
    {
        return BaseProjectileDamage;
    }

    public void SetNewProjectileAttack(float i)
    {
        ProjectileDamage = i;
        Debug.Log("New Projectile Attack Damage: " + ProjectileDamage);
    }

    public float GetBaseBeamAttack()
    {
        return BaseBeamDamage;
    }

    public void SetNewBeamAttack(float i)
    {
        BeamDamage = i;
        Debug.Log("New Beam Attack Damage: " + BeamDamage);
    }

    public float GetBaseAuraAttack()
    {
        return BaseAuraDamage;
    }

    public void SetNewAuraAttack(float i)
    {
        AuraDamage = i;
        Debug.Log("New Aura Attack Damage: " + AuraDamage);
    }
}
