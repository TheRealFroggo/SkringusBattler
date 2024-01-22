using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject dronePrefab;
    [SerializeField] private GameObject chargerPrefab;
    [SerializeField] private GameObject shooterPrefab;
    [SerializeField] private GameObject spikerPrefab;

    [SerializeField] private float droneInterval = 2f;
    [SerializeField] private float chargerInterval = 2f;
    [SerializeField] private float shooterInterval = 2f;
    [SerializeField] private float spikerInterval = 2f;

    private float _timeElapsed;
    [SerializeField] private float spawnRange = 4f;


    private bool shooterStart = false;
    private bool chargerStart = false;
    private bool spikerStart = false;

    void Start()
    {
        _timeElapsed = 0f;
        //StartCoroutine(spawnEnemy(droneInterval, dronePrefab));
        StartCoroutine(spawnDrone());
    }

    void Update()
    {
        _timeElapsed += Time.deltaTime;
        int minutes = (int)(_timeElapsed / 60 + 0.5);
        droneInterval = (float)(1/(0.4*minutes+0.5));
        shooterInterval = (float)(1/(0.4*minutes));

        switch (minutes)
        {
            case 1:
                if (shooterStart == false)
                {
                    shooterStart = true;
                    StartCoroutine(spawnShooter());
                }
                break;
            case 3:
                if (chargerStart == false)
                {
                    chargerStart = true;
                    StartCoroutine(spawnCharger());
                }
                break;
            case 5:
                if (spikerStart == false)
                {
                    spikerStart = true;
                    StartCoroutine(spawnSpiker());
                }
                break;
            default:
                break;
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        var playerPosition = player.transform.position;
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, (playerPosition+Vector3.Normalize(Random.insideUnitCircle)*spawnRange), Quaternion.identity);

        StartCoroutine(spawnEnemy(interval, enemy));
    }
    
    private IEnumerator spawnDrone()
    {
        var playerPosition = player.transform.position;
        yield return new WaitForSeconds(droneInterval);
        GameObject newEnemy = Instantiate(dronePrefab, (playerPosition+Vector3.Normalize(Random.insideUnitCircle)*spawnRange), Quaternion.identity);

        StartCoroutine(spawnDrone());
    }
    
    private IEnumerator spawnShooter()
    {
        var playerPosition = player.transform.position;
        yield return new WaitForSeconds(shooterInterval);
        GameObject newEnemy = Instantiate(shooterPrefab, (playerPosition+Vector3.Normalize(Random.insideUnitCircle)*spawnRange), Quaternion.identity);

        StartCoroutine(spawnShooter());
    }
    
    private IEnumerator spawnCharger()
    {
        var playerPosition = player.transform.position;
        yield return new WaitForSeconds(chargerInterval);
        GameObject newEnemy = Instantiate(chargerPrefab, (playerPosition+Vector3.Normalize(Random.insideUnitCircle)*spawnRange), Quaternion.identity);

        StartCoroutine(spawnCharger());
    }
    private IEnumerator spawnSpiker()
    {
        var playerPosition = player.transform.position;
        Vector2 position = playerPosition + Vector3.Normalize(Random.insideUnitCircle) * spawnRange;
        yield return new WaitForSeconds(spikerInterval);
        GameObject newEnemy = Instantiate(spikerPrefab, (position+Vector2.right), Quaternion.identity);
        GameObject newEnemy1 = Instantiate(spikerPrefab, (position+Vector2.down), Quaternion.identity);
        GameObject newEnemy2 = Instantiate(spikerPrefab, (position), Quaternion.identity);

        StartCoroutine(spawnSpiker());
    }
}