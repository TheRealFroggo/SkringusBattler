using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    
    private static GameManager _instance;
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
    }
}
