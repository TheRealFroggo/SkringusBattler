using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerViruses : MonoBehaviour
{
    [SerializeField] List<Slots> PlayerSlots;
    [SerializeField] List<Virus> Viruses;
    [SerializeField] float VirusTickRate;

    float VirusTickRateTimer = 0.0f;

    void Start()
    {
        //Add a random Virus to the Body
        VirusID startingBodyVirus = (VirusID)Random.Range(0, 3);
        Viruses.Add(new Virus(startingBodyVirus, 1, Slots.BODY));
        Debug.Log(Viruses[0].GetDisplayName() + " is affecting " + Slots.BODY);

        //Add another random virus somewhere else
        VirusID startingRandVirus = (VirusID)Random.Range(0, 3);
        Slots startingSlot = (Slots)Random.Range(0, 5);
        while (startingSlot == Slots.BODY)
            startingSlot = (Slots)Random.Range(0, 5);
        Viruses.Add(new Virus(startingRandVirus, 0, startingSlot));
        Debug.Log(Viruses[1].GetDisplayName() + " is affecting " + startingSlot);
    }

    void Update()
    {
        bool doVirusTick = TickVirusTimer();

        if (doVirusTick)
        {
            SimulateViruses();
            doVirusTick = false;
            VirusTickRateTimer = 0.0f;
        }
    }

    //Every x seconds, trigger a simulation of viruses
    bool TickVirusTimer()
    {
        VirusTickRateTimer += Time.deltaTime;
        if (VirusTickRateTimer > VirusTickRate)
            return true;
        return false;
    }

    void SimulateViruses()
    {
        Debug.Log("Simulating Viruses");
        foreach (Virus virus in Viruses)
        {
            int randomSpread = Random.Range(1, 100);
            //Debug.Log(virus.GetDisplayName() + " is spreading with " + randomSpread);
            if (randomSpread <
                virus.CurrentVirus.Stages[virus.CurrentStage].SpreadPercentage)
            {
                //Spread Virus to nearby cell randdomly
                Debug.Log(virus.GetDisplayName() + " affecting " + virus.CurrentSlot + " has spread!");
            }

            int randomGrowth = Random.Range(1, 100);
            //Debug.Log(virus.GetDisplayName() + " is growing with " +randomGrowth);
            if (randomGrowth <
                virus.CurrentVirus.Stages[virus.CurrentStage].GrowthPercentage)
            {
                //Increase stage
                Debug.Log(virus.GetDisplayName() + " affecting " + virus.CurrentSlot + " has grown to " + virus.GetDisplayName(1));
                virus.CurrentStage++;
            }
        }
    }
}

[System.Serializable]
public class Virus
{
    [SerializeField] public VirusObject CurrentVirus;
    [SerializeField] public int CurrentStage;
    [SerializeField] public Slots CurrentSlot;

    private string DisplayName;

    public Virus(VirusID id, int stage, Slots slot)
    {
        switch (id)
        {
            case VirusID.BLORCH:
                CurrentVirus = GameManager.Instance.GetVirusObject(0);
                break;
            case VirusID.GUMBO:
                CurrentVirus = GameManager.Instance.GetVirusObject(1);
                break;
            case VirusID.SKRINGUS:
                CurrentVirus = GameManager.Instance.GetVirusObject(2);
                break;
            case VirusID.WUMBUS:
                CurrentVirus = GameManager.Instance.GetVirusObject(3);
                break;
        }
        CurrentStage = stage;
        CurrentSlot = slot;
    }

    public void IncreaseVirusIntensity()
    {
        CurrentStage++;
    }

    public string GetDisplayName()
    {
        DisplayName = CurrentVirus.Stages[CurrentStage].StageName + " " + CurrentVirus.name;
        return DisplayName;
    }
    public string GetDisplayName(int i)
    {
        DisplayName = CurrentVirus.Stages[CurrentStage + i].StageName + " " + CurrentVirus.name;
        return DisplayName;
    }
}

public enum Slots
{
    HEAD, BODY, SHIELD, EMITTER, TREADS, MOTOR
}