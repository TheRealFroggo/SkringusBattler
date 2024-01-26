using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class TabMenu : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] GameObject UI;
    [SerializeField] private float camDist = 4f;
    [SerializeField] private float zoomAmount = 0.25f;
    [SerializeField] private float slowAmount = 0f;
    private bool isSlow = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CinemachineFramingTransposer composer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (Input.GetKeyDown(KeyCode.Tab)) isSlow = !isSlow;
        Time.timeScale = isSlow ? slowAmount : 1f;
        vcam.m_Lens.OrthographicSize = isSlow ? zoomAmount * camDist : camDist;
        composer.m_SoftZoneWidth = isSlow ? 0f : 0.8f;
        composer.m_SoftZoneHeight = isSlow ? 0f : 0.8f;
        UI.SetActive(isSlow);
        GameManager.Instance.player.GetComponent<PlayerShoot>().enabled = !isSlow;
    }
}
