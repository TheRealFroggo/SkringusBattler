using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFollow : MonoBehaviour
{
    private GameObject _target;
    public float speed = 1f;
    public float stopDistance = 0.25f;
    [SerializeField] private float Damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameManager.Instance.player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, _target.transform.position) > stopDistance)
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
        LookAt2D(transform, _target.transform.position);
    }
    
    private static void LookAt2D(Transform transform, Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
