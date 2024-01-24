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
        AddVirus(startingBodyVirus, Slots.BODY);

        //Add another random virus somewhere else
        VirusID startingRandVirus = (VirusID)Random.Range(0, 3);
        Slots startingSlot = (Slots)Random.Range(0, 5);
        while (startingSlot == Slots.BODY)
            startingSlot = (Slots)Random.Range(0, 5);
        AddVirus(startingRandVirus, startingSlot);
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
            if (randomSpread <
                virus.CurrentVirus.Stages[virus.CurrentStage].SpreadPercentage)
            {
                //Spread Virus to nearby cell randdomly
                Debug.Log(virus.GetDisplayName() + " affecting " + virus.CurrentSlot + " has spread!");

                bool didSpread = false;
                switch (virus.CurrentSlot)
                {
                    case Slots.HEAD:
                        didSpread = CheckAddVirus(virus, new Slots[1] {Slots.BODY});
                        break;
                    case Slots.BODY:
                        didSpread = CheckAddVirus(virus, new Slots[5] {Slots.HEAD, Slots.SHIELD, Slots.MOTOR, Slots.TREADS, Slots.EMITTER});
                        break;
                    case Slots.SHIELD:
                        didSpread = CheckAddVirus(virus, new Slots[2] {Slots.BODY, Slots.MOTOR});
                        break;
                    case Slots.EMITTER:
                        didSpread = CheckAddVirus(virus, new Slots[2] {Slots.BODY, Slots.TREADS});
                        break;
                    case Slots.TREADS:
                        didSpread = CheckAddVirus(virus, new Slots[3] {Slots.BODY, Slots.EMITTER, Slots.TREADS});
                        break;
                    case Slots.MOTOR:
                        didSpread = CheckAddVirus(virus, new Slots[3] {Slots.BODY, Slots.SHIELD, Slots.TREADS});
                        break;
                }
                if (didSpread)
                    break;
            }

            int randomGrowth = Random.Range(1, 100);
            if (randomGrowth <
                virus.CurrentVirus.Stages[virus.CurrentStage].GrowthPercentage)
            {
                //Increase stage
                Debug.Log(virus.GetDisplayName() + " affecting " + virus.CurrentSlot + " has grown to " + virus.GetDisplayName(1));
                virus.CurrentStage++;
            }
        }
    }

    bool AddVirus(VirusID virus, Slots slot)
    {
        Viruses.Add(new Virus(virus, 0, slot));
        GetComponent<PlayerStatusEffects>().AddStatusEffect(virus, slot);

        return true;
    }

    bool CheckAddVirus(Virus virus, Slots[] spreadableSlots)
    {
        Slots newSlot = spreadableSlots[Random.Range(0, spreadableSlots.Length-1)];

        //Check if cell selected already has virus
        bool shouldSpread = true;
        foreach (Virus v in Viruses)
            if (v.CurrentSlot == newSlot && v.CurrentVirus == virus.CurrentVirus)
                shouldSpread = false;

        //If not, then spread
        if (shouldSpread)
            AddVirus(virus.CurrentVirus.GetVirusID(), newSlot);
        return shouldSpread;
    }

    public Virus FindVirus(VirusID vir, Slots slot)
    {
        Virus virus;
        foreach (Virus v in Viruses)
            if (v.CurrentSlot == slot && v.CurrentVirus.GetVirusID() == vir)
            {
                virus = v;
                return virus;
            }
        return null;
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