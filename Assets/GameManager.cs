using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private static GameManager _instance;
    [SerializeField] private List<VirusObject> VirusObjectsList;

    public static GameManager Instance
    {
        get
        {
            if (!_instance)
                Debug.LogError("Game Manager is NULL");
            
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        //Debug.Log(_instance.name);
    }

    public VirusObject GetVirusObject(int id)
    {
        return VirusObjectsList[id];
    }
}
