using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

public class GameManager : MonoBehaviour
{
    int Score;
    public GameObject player;
    private static GameManager _instance;
    [SerializeField] private List<VirusObject> VirusObjectsList;
    [SerializeField] GameObject GameOver;

    [UDictionary.Split(70, 30)]
    [SerializeField] UDictionary1 StatusDictionary;
    [Serializable]
    [SerializeField] class UDictionary1 : UDictionary<string, StatusEffectData> {};

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
        Score = 0;
    }

    public VirusObject GetVirusObject(int id)
    {
        return VirusObjectsList[id];
    }

    public StatusEffectData GetStatusEffect(string slot)
    {
        return StatusDictionary[slot];
    }

    public void AddScore(int i)
    {
        Score += i;
    }

    public int GetScore()
    {
        return Score;
    }

    public void EndGame()
    {
        GameOver.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("SceneMatt");
    }
}
