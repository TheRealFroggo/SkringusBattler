using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private float _nextFire = 0;
    [SerializeField] private GameObject playerBulletPrefab;
    [SerializeField] public float fireRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0) || !(_nextFire < Time.time)) return;
        GameObject newProj = Instantiate(playerBulletPrefab, transform.position, Quaternion.identity);
        _nextFire = Time.time + fireRate;
    }
}
