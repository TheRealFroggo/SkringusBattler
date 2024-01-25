using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outpost : MonoBehaviour
{
    [SerializeField] List<VirusID> Viruses;
    [SerializeField] float Radius;
    GameObject Player;
    [SerializeField] float ActivationTime;
    [SerializeField] float OutpostDownTime;
    float ActivationTimer = 0.0f;
    float OutpostDownTimeTimer = 0.0f;
    bool isOutpostActive = true;

    void Start()
    {
        GenerateVirusCode();
        Player = GameManager.Instance.player;
    }

    void Update()
    {
        CheckDistanceToPlayer(Time.deltaTime);
        ResetOutPost(Time.deltaTime);
    }

    void CheckDistanceToPlayer(float deltaTime)
    {
        if (isOutpostActive)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) < Radius)
            {
                ActivationTimer += deltaTime;

                if (ActivationTimer >= ActivationTime)
                {
                    isOutpostActive = false;
                    ActivationTimer = 0.0f;
                }
            }
            else
                ActivationTimer = 0.0f;
        }
    }

    void ResetOutPost(float deltaTime)
    {
        if (!isOutpostActive)
        {
            if (OutpostDownTimeTimer >= OutpostDownTime)
            {
                GenerateVirusCode();
                isOutpostActive = true;
                OutpostDownTimeTimer = 0.0f;
            }
            else
                OutpostDownTimeTimer += deltaTime;
        }
        else
            OutpostDownTimeTimer = 0.0f;
    }

    void GenerateVirusCode()
    {
        Viruses.Clear();

        int virusesRequired = Random.Range(1, 3);

        for (int i = 0; i < virusesRequired; i++)
        {
            VirusID id;

            do
            {
                id = (VirusID)Random.Range(1, 4);
            } while (Viruses.Contains(id));
            Viruses.Add(id);
        }
    }
}
