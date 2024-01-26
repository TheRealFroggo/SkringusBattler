using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSelector : MonoBehaviour
{
    public Slots ActiveDisplaySlot;
    
    void OnEnable()
    {
        
    }

    void Update()
    {
        transform.position = GameManager.Instance.player.transform.position;
    }
}
