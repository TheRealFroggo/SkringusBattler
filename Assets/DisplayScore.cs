using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    private void OnEnable()
    {
        int score = GameManager.Instance.GetScore();

        GetComponent<TextMeshProUGUI>().text = "Score: " + score + "\nPlay Again?";
    }
}
