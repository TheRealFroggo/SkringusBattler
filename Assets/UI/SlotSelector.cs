using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SlotSelector : MonoBehaviour
{
    public Slots ActiveDisplaySlot;
    [SerializeField] public TextMeshPro VirusText;

    void Update()
    {
        transform.position = GameManager.Instance.player.transform.position;

        DisplayStats();
    }

    void DisplayStats()
    {
        string displayText = "";
        foreach(Virus virus in GameManager.Instance.player.GetComponent<PlayerViruses>().Viruses)
        {

            if (virus.CurrentSlot == ActiveDisplaySlot)
            {
                string virusSlot = virus.CurrentVirus.GetVirusID().ToString() + ActiveDisplaySlot.ToString();
                StatusEffectData effect = GameManager.Instance.GetStatusEffect(virusSlot);

                displayText += virus.CurrentVirus.GetVirusID().ToString() + "\n" + effect.Description + "\n";
            }
        }

        VirusText.text = displayText;
    }

    void OnMouseOver()
    {
        VirusText.enabled = true;
    }

    void OnMouseExit()
    {
        VirusText.enabled = false;
    }
}
