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
    Dictionary<string, float> ClickDamangeModifiers;
    Dictionary<string, float> ProjectileDamageModifiers;
    Dictionary<string, float> BeamDamageModifiers;
    Dictionary<string, float> AuraDamageModifiers;

    void Start()
    {
        HealthModifiers = new Dictionary<string, float>();
        HealthRegenModifiers = new Dictionary<string, float>();
        MovementModifiers = new Dictionary<string, float>();
        DamageModifiers = new Dictionary<string, float>();
        ClickDamangeModifiers = new Dictionary<string, float>();
        ProjectileDamageModifiers = new Dictionary<string, float>();
        BeamDamageModifiers = new Dictionary<string, float>();
        AuraDamageModifiers = new Dictionary<string, float>();
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
        if (effect.ClickDamangeModifier != 0)
        {
            ClickDamangeModifiers.Add(virusSlot, effect.ClickDamangeModifier);
            RecalculateClickDamage(virus, slot);
        }
        if (effect.ProjectileDamageModifier != 0)
        {
            ProjectileDamageModifiers.Add(virusSlot, effect.ProjectileDamageModifier);
            RecalculateProjectileDamage(virus, slot);
        }
        if (effect.BeamDamageModifier != 0)
        {
            BeamDamageModifiers.Add(virusSlot, effect.BeamDamageModifier);
            RecalculateBeamDamage(virus, slot);
        }
        if (effect.AuraDamageModifier != 0)
        {
            AuraDamageModifiers.Add(virusSlot, effect.AuraDamageModifier);
            RecalculateAuraDamage(virus, slot);
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
        if (effect.ClickDamangeModifier != 0)
        {
            ClickDamangeModifiers.Remove(virusSlot);
            RecalculateClickDamage(virus, slot);
        }
        if (effect.ProjectileDamageModifier != 0)
        {
            ProjectileDamageModifiers.Remove(virusSlot);
            RecalculateProjectileDamage(virus, slot);
        }
        if (effect.BeamDamageModifier != 0)
        {
            BeamDamageModifiers.Remove(virusSlot);
            RecalculateBeamDamage(virus, slot);
        }
        if (effect.AuraDamageModifier != 0)
        {
            AuraDamageModifiers.Remove(virusSlot);
            RecalculateAuraDamage(virus, slot);
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
        foreach (KeyValuePair<string, float> entry in HealthModifiers)
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
        foreach (KeyValuePair<string, float> entry in HealthModifiers)
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
        float dmg = GetComponent<PlayerAttack>().GetBaseAttack();
        foreach (KeyValuePair<string, float> entry in HealthModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("Attack: " + dmg + " | AttackMod: " + mod + " | StageMod: " + stageMod);
            }
            
            dmg += mod * stageMod;
        }
        GetComponent<PlayerAttack>().SetNewAttack(dmg);
    }

    void RecalculateClickDamage(VirusID virus, Slots slot)
    {
        float dmg = GetComponent<PlayerAttack>().GetBaseClickAttack();
        foreach (KeyValuePair<string, float> entry in HealthModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("Click Attack: " + dmg + " | ClickMod: " + mod + " | StageMod: " + stageMod);
            }
            
            dmg += mod * stageMod;
        }
        GetComponent<PlayerAttack>().SetNewClickAttack(dmg);
    }

    void RecalculateProjectileDamage(VirusID virus, Slots slot)
    {
        float dmg = GetComponent<PlayerAttack>().GetBaseProjectileAttack();
        foreach (KeyValuePair<string, float> entry in HealthModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("Projectile Attack: " + dmg + " | ProjectileMod: " + mod + " | StageMod: " + stageMod);
            }
            
            dmg += mod * stageMod;
        }
        GetComponent<PlayerAttack>().SetNewProjectileAttack(dmg);
    }

    void RecalculateBeamDamage(VirusID virus, Slots slot)
    {
        float dmg = GetComponent<PlayerAttack>().GetBaseBeamAttack();
        foreach (KeyValuePair<string, float> entry in HealthModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("Beam Attack: " + dmg + " | BeamMod: " + mod + " | StageMod: " + stageMod);
            }
            
            dmg += mod * stageMod;
        }
        GetComponent<PlayerAttack>().SetNewBeamAttack(dmg);
    }

    void RecalculateAuraDamage(VirusID virus, Slots slot)
    {
        float dmg = GetComponent<PlayerAttack>().GetBaseAuraAttack();
        foreach (KeyValuePair<string, float> entry in HealthModifiers)
        {
            float stageMod = 1.0f;
            float mod = entry.Value;
            VirusObject virusObj = GameManager.Instance.GetVirusObject((int)virus);
            Virus v = GetComponent<PlayerViruses>().FindVirus(virus, slot);
            if (v != null)
            {
                stageMod = virusObj.Stages[v.CurrentStage].Multiplier;
                Debug.Log("Aura Attack: " + dmg + " | AuraMod: " + mod + " | StageMod: " + stageMod);
            }
            
            dmg += mod * stageMod;
        }
        GetComponent<PlayerAttack>().SetNewAuraAttack(dmg);
    }
}
