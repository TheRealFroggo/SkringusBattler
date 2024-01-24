using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int MaxHealth;
    [SerializeField] int CurrentHealth;
    [SerializeField] int HealthRegen;

    float HealthRegenTimer = 0.0f;

    void Start()
    {
        CurrentHealth = MaxHealth;
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
            CurrentHealth += HealthRegen;
            if (CurrentHealth >= MaxHealth)
                CurrentHealth = MaxHealth;
        }
    }

    void PlayerDied()
    {
        //Handle Player death and Restart game.
    }
}
