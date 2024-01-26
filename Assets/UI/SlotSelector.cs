using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSelector : MonoBehaviour
{
    public Slots ActiveDisplaySlot;
    bool ArrowDisplay;

    void OnEnable()
    {
        ArrowDisplay = false;
    }

    void Update()
    {
        transform.position = GameManager.Instance.player.transform.position;
    }
}
