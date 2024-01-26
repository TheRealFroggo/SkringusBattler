using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    float AttackDamage;
    float Pierce;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Pierce -= 1;

            if (Pierce <= 0)
                Destroy(gameObject);
        }
    }

    public void SetNewDamage(float i)
    {
        AttackDamage = i;
    }

    public float GetDamage()
    {
        return AttackDamage;
    }

    public void SetNewPierce(float i)
    {
        Pierce = i;
    }
}
