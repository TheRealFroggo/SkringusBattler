using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int Damage;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();

            health.DealDamage(Damage);
        }
    }

    void OnTriggerEnter2D(Collider2D other)    
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();

            health.DealDamage(Damage);
        }
    }
}
