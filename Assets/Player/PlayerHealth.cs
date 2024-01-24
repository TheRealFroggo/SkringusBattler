using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int BaseMaxHealth;
    [SerializeField] int CurrentHealth;
    [SerializeField] int BaseHealthRegen;
    int CurrentMaxHealth;
    int CurrentHealthRegen;

    float HealthRegenTimer = 0.0f;

    void Awake()
    {
        CurrentMaxHealth = BaseMaxHealth;
        CurrentHealth = CurrentMaxHealth;

        CurrentHealthRegen = BaseHealthRegen;
    }

    void Update()
    {
        RegenHealth(Time.deltaTime);

        if (CurrentHealth <= 0)
        {
            PlayerDied();
        }
    }

    void RegenHealth(float deltaTime)
    {
        HealthRegenTimer += deltaTime;
        if (HealthRegenTimer >= 1.0f)
        {
            HealthRegenTimer = 0.0f;
            CurrentHealth += CurrentHealthRegen;

            if (CurrentHealth >= CurrentMaxHealth)
                CurrentHealth = CurrentMaxHealth;
        }
    }

    public int GetBaseMaxHealth()
    {
        return BaseMaxHealth;
    }

    public int GetBaseMaxHealthRegen()
    {
        return BaseHealthRegen;
    }

    public void SetNewMaxHealth(int i)
    {
        CurrentMaxHealth = i;
        Debug.Log("New Max Health: " + CurrentMaxHealth);
    }

    public void SetNewMaxHealthRegen(int i)
    {
        CurrentHealthRegen = i;
        Debug.Log("New Health Regen: " + CurrentHealthRegen);
    }

    void PlayerDied()
    {
        //Handle Player death and Restart game.
    }
}
