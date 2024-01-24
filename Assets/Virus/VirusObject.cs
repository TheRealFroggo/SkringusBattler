using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

[CreateAssetMenu(menuName = "Virus")]
public class VirusObject : ScriptableObject
{
    [SerializeField] VirusID VirusID;
    [SerializeField] public Sprite Sprite;
    [SerializeField] public VirusStage[] Stages;

    public VirusID GetVirusID()
    {
        return VirusID;
    }
}

[System.Serializable]
public class VirusStage
{
    public string StageName;
    public float SpreadPercentage;
    public float GrowthPercentage;
    public float Multiplier;
}

public enum VirusID
{
    BLORCH, GUMBO, SKRINGUS, WUMBUS
}