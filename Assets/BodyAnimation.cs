using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnimation : MonoBehaviour
{
    Animator m_Animator;
    private GameObject player;
    private PlayerMove _playerMove;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.player;
        _playerMove = player.GetComponent<PlayerMove>();
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerMove.isMoving)
        {
            m_Animator.Play("Body_Move");
        }
        else
        {
            
            m_Animator.Play("Body_Idle");
        }
    }
}
