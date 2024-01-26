using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotsDisplay : MonoBehaviour
{
    [SerializeField] public Slots DisplaySlot;
    [SerializeField] GameObject ArrowDisplay;

    bool isEnabled;

    void Update()
    {
        ArrowDisplay.SetActive(isEnabled);
    }

    void OnMouseOver()
    {
        GetComponentInParent<SlotSelector>().ActiveDisplaySlot = DisplaySlot;
        isEnabled = true;
    }

    void OnMouseExit()
    {
        isEnabled = false;
    }

    void OnEnable()
    {
        isEnabled = false;
    }

    public void EnableArrow(bool b)
    {
        ArrowDisplay.SetActive(b);
    }
}
