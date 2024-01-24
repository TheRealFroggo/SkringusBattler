using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShooterShoot : MonoBehaviour
{
    private float _nextFire = 0;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] public float fireRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_nextFire < Time.time)
        {
            GameObject newEnemy = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            _nextFire = Time.time + fireRate;
        }
    }
}
