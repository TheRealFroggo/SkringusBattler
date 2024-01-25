using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float BaseDamage;
    [SerializeField] int Pierce;
    float CurrentDamage;

    void Start()
    {
        CurrentDamage = BaseDamage;
    }

    public float GetDamage()
    {
        return CurrentDamage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Pierce -= 1;

            if (Pierce <= 0)
                Destroy(gameObject);
        }
    }
}
