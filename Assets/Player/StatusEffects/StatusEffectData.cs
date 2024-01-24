using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StatusEffect")]
public class StatusEffectData : ScriptableObject
{
    public string Description;
    [Header("Health")]
    public float HealthModifier;
    public float HealthRegenModifier;
    [Header("Speed")]
    public float MovementModifier;
    [Header("Damage")]
    public float DamageModifier;
    public float ClickDamangeModifier;
    public float ProjectileDamageModifier;
    public float BeamDamageModifier;
    public float AuraDamageModifier;
}
