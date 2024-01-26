using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetMouseButtonDown(0))
        {
            GetComponentInParent<SlotSelector>().ActiveDisplaySlot = DisplaySlot;
            isEnabled = !isEnabled;
        }
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
