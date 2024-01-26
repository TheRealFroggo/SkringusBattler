using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float MaxHealth;
    [SerializeField] float Points;
    [SerializeField] private ParticleSystem DeathAnim;
    float CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        if (CurrentHealth <= 0.0f)
        {
            GameObject explode = Instantiate(DeathAnim.gameObject, transform.position, Quaternion.identity);
            Destroy(explode, 1f);
            Destroy(gameObject); 
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerBullet(Clone)")
        {
            Damage damage = other.gameObject.GetComponent<Damage>();

            if (damage != null)
                CurrentHealth -= damage.GetDamage();
        }
    }
}
