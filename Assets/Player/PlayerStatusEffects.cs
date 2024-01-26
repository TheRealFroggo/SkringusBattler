using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatusEffects : MonoBehaviour
{
    Dictionary<string, float> HealthModifiers;
    Dictionary<string, float> HealthRegenModifiers;
    Dictionary<string, float> MovementModifiers;
    Dictionary<string, float> DamageModifiers;
    Dictionary<string, float> FireRateModifiers;
    Dictionary<string, float> ProjectileSizeModifiers;
    Dictionary<string, float> ProjectileSpeedModifiers;
    Dictionary<string, float> ProjectilePierceModifiers;
    Dictionary<string, float> ProjectileCountModifiers;
    Dictionary<string, float> ProjectileLifeSpanModifiers;

    void Start()
    {
        HealthModifiers = new Dictionary<string, float>();
        HealthRegenModifiers = new Dictionary<string, float>();
        MovementModifiers = new Dictionary<string, float>();
        DamageModifiers = new Dictionary<string, float>();
        FireRateModifiers = new Dictionary<string, float>();
        ProjectileSizeModifiers = new Dictionary<string, float>();
        ProjectileSpeedModifiers = new Dictionary<string, float>();
        ProjectilePierceModifiers = new Dictionary<string, float>();
        ProjectileCountModifiers = new Dictionary<string, float>();
        ProjectileLifeSpanModifiers = new Dictionary<string, float>();
    }

    public void AddStatusEffect(VirusID virus, Slots slot)
    {
        AddStat(virus, slot);
    }

    public void RemoveStatusEffect(VirusID virus, Slots slot)
    {
        RemoveStat(virus, slot);
    }

    void AddStat(VirusID virus, Slots slot)
    {
        string virusSlot = virus.ToString() + slot.ToString();
        StatusEffectData effect = GameManager.Instance.GetStatusEffect(virusSlot);
        Debug.Log(effect.Description + "\n" + virusSlot + " Added");

        if (effect.HealthModifier != 0)
        {
            HealthModifiers.Add(virusSlot, effect.HealthModifier);
            RecalculateHealth(virus, slot);
        }
        if (effect.HealthRegenModifier != 0)
        {
            HealthRegenModifiers.Add(virusSlot, effect.HealthRegenModifier);
            RecalculateHealthRegen(virus, slot);
        }
        if (effect.MovementModifier != 0)
        {
            MovementModifiers.Add(virusSlot, effect.MovementModifier);
            RecalculateMovement(virus, slot);
        }
        if (effect.DamageModifier != 0)
        {
            DamageModifiers.Add(virusSlot, effect.DamageModifier);
            RecalculateDamage(virus, slot);
        }
        if (effect.FireRateModifier != 0)
        {
            FireRateModifiers.Add(virusSlot, effect.FireRateModifier);
            RecalculateFireRate(virus, slot);
        }
        if (effect.ProjectileSizeModifier != 0)
        {
            ProjectileSizeModifiers.Add(virusSlot, effect.ProjectileSizeModifier);
            RecalculateProjSize(virus, slot);
        }
        if (effect.ProjectileSpeedModifier != 0)
        {
            ProjectileSpeedModifiers.Add(virusSlot, effect.ProjectileSpeedModifier);
            RecalculateProjSpeed(virus, slot);
        }
        if (effect.ProjectilePierceModifier != 0)
        {
            ProjectilePierceModifiers.Add(virusSlot, effect.ProjectilePierceModifier);
            RecalculateProjPierce(virus, slot);
        }
        if (effect.ProjectileCountModifier != 0)
        {
            ProjectileCountModifiers.Add(virusSlot, effect.ProjectileCountModifier);
            RecalculateProjCount(virus, slot);
        }
        if (effect.ProjectileLifeSpanModifier != 0)
        {
            ProjectileLifeSpanModifiers.Add(virusSlot, effect.ProjectileLifeSpanModifier);
            RecalculateProjLifeSpan(virus, slot);
        }
    }

    void RemoveStat(VirusID virus, Slots slot)
    {
        string virusSlot = virus.ToString() + slot.ToString();
        StatusEffectData effect = GameManager.Instance.GetStatusEffect(virusSlot);
        Debug.Log(effect.Description + "\n" + virusSlot + " Removed");

        if (effect.HealthModifier != 0)
        {
            HealthModifiers.Remove(virusSlot);
            RecalculateHealth(virus, slot);
        }
        if (effect.HealthRegenModifier != 0)
        {
            HealthRegenModifiers.Remove(virusSlot);
            RecalculateHealthRegen(virus, slot);
        }
        if (effect.MovementModifier != 0)
        {
            MovementModifiers.Remove(virusSlot);
            RecalculateMovement(virus, slot);
        }
        if (effect.DamageModifier != 0)
        {
            DamageModifiers.Remove(virusSlot);
            RecalculateDamage(virus, slot);
        }
        if (effect.FireRateModifier != 0)
        {
            FireRateModifiers.Remove(virusSlot);
            RecalculateFireRate(virus, slot);
        }
        if (effect.ProjectileSizeModifier != 0)
        {
            ProjectileSizeModifiers.Remove(virusSlot);
            RecalculateProjSize(virus, slot);
        }
        if (effect.ProjectileSpeedModifier != 0)
        {
            ProjectileSpeedModifiers.Remove(virusSlot);
            RecalculateProjSpeed(virus, slot);
        }
        if (effect.ProjectilePierceModifier != 0)
        {
            ProjectilePierceModifiers.Remove(virusSlot);
            RecalculateProjPierce(virus, slot);
        }
        if (effect.ProjectileCountModifier != 0)
        {
            ProjectileCountModifiers.Remove(virusSlot);
            RecalculateProjCount(virus, slot);
        }
        if (effect.ProjectileLifeSpanModifier != 0)
        {
            ProjectileLifeSpanModifiers.Remove(virusSlot);
            RecalculateProjLifeSpan(virus, slot);
        }
    }

    void RecalculateHealth(VirusID virus, Slots slot)
    {
        float health = GetComponent<PlayerHealth>().GetBaseMaxHealth();
        foreach (KeyValuePair<string, float> entry in HealthModifiers)
        {
            float stageMod = 1.0f;
            float healthMod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("Health: " + health + " | HealthMod: " + healthMod + " | StageMod: " + stageMod);
            }
            
            health += healthMod * stageMod;
        }
        GetComponent<PlayerHealth>().SetNewMaxHealth((int)health);
    }

    void RecalculateHealthRegen(VirusID virus, Slots slot)
    {
        float healthRegen = GetComponent<PlayerHealth>().GetBaseMaxHealthRegen();
        foreach (KeyValuePair<string, float> entry in HealthRegenModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("HealthRegen: " + healthRegen + " | RegenMod: " + mod + " | StageMod: " + stageMod);
            }
            
            healthRegen += mod * stageMod;
        }
        GetComponent<PlayerHealth>().SetNewMaxHealthRegen((int)healthRegen);
    }

    void RecalculateMovement(VirusID virus, Slots slot)
    {
        float speed = GetComponent<PlayerMove>().GetBaseMaxHealthRegen();
        foreach (KeyValuePair<string, float> entry in MovementModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("Speed: " + speed + " | SpeedMod: " + mod + " | StageMod: " + stageMod);
            }
            
            speed += mod * stageMod;
        }
        GetComponent<PlayerMove>().SetNewCurrentSpeed(speed);
    }

    void RecalculateDamage(VirusID virus, Slots slot)
    {
        float dmg = GetComponent<PlayerShoot>().GetBaseDamage();
        foreach (KeyValuePair<string, float> entry in DamageModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("Damage: " + dmg + " | DamageMod: " + mod + " | StageMod: " + stageMod);
            }
            
            dmg += mod * stageMod;
        }
        GetComponent<PlayerShoot>().SetNewDamage(dmg);
    }

    void RecalculateFireRate(VirusID virus, Slots slot)
    {
        float rate = GetComponent<PlayerShoot>().GetBaseFireRate();
        foreach (KeyValuePair<string, float> entry in FireRateModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("FireRate: " + rate + " | FireRateMod: " + mod + " | StageMod: " + stageMod);
            }
            
            rate += mod * stageMod;
        }
        GetComponent<PlayerShoot>().SetNewFireRate(rate);
    }

    void RecalculateProjSize(VirusID virus, Slots slot)
    {
        float size = GetComponent<PlayerShoot>().GetBaseProjectileSize();
        foreach (KeyValuePair<string, float> entry in ProjectileSizeModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("ProjSize: " + size + " | ProjSizeMod: " + mod + " | StageMod: " + stageMod);
            }
            
            size += mod * stageMod;
        }
        GetComponent<PlayerShoot>().SetNewProjectileSize(size);
    }

    void RecalculateProjSpeed(VirusID virus, Slots slot)
    {
        float speed = GetComponent<PlayerShoot>().GetBaseProjectileSpeed();
        foreach (KeyValuePair<string, float> entry in ProjectileSpeedModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("ProjSpeed: " + speed + " | ProjSpeedMod: " + mod + " | StageMod: " + stageMod);
            }
            
            speed += mod * stageMod;
        }
        GetComponent<PlayerShoot>().SetNewProjectileSpeed(speed);
    }

    void RecalculateProjPierce(VirusID virus, Slots slot)
    {
        float pierce = GetComponent<PlayerShoot>().GetBaseProjectilePierce();
        foreach (KeyValuePair<string, float> entry in ProjectilePierceModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("ProjPierce: " + pierce + " | ProjPierceMod: " + mod + " | StageMod: " + stageMod);
            }
            
            pierce += mod * stageMod;
        }
        GetComponent<PlayerShoot>().SetNewProjectilePierce(pierce);
    }

    void RecalculateProjCount(VirusID virus, Slots slot)
    {
        float count = GetComponent<PlayerShoot>().GetBaseProjectileCount();
        foreach (KeyValuePair<string, float> entry in ProjectileCountModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("ProjCount: " + count + " | ProjCountMod: " + mod + " | StageMod: " + stageMod);
            }
            
            count += mod * stageMod;
        }
        GetComponent<PlayerShoot>().SetNewProjectileCount(count);
    }

    void RecalculateProjLifeSpan(VirusID virus, Slots slot)
    {
        float span = GetComponent<PlayerShoot>().GetBaseProjectileLifeSpan();
        foreach (KeyValuePair<string, float> entry in ProjectileLifeSpanModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("ProjLifeSpan: " + span + " | ProjLifeSpanMod: " + mod + " | StageMod: " + stageMod);
            }
            
            span += mod * stageMod;
        }
        GetComponent<PlayerShoot>().SetNewProjectileLifeSpan(span);
    }
}
