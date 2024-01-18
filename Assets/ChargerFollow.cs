using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChargerFollow : MonoBehaviour
{
    private GameObject _target;
    public float speed = 5f;
    public float stopDistance = 0.25f;
    public float overshoot = 1f;
    private float nextChargeTime = 0;
    public float chargeRate = 1f;
    private Vector3 _destination;

    public float smoothTime = 2;
    private bool _lockOn = false;
    // Start is called before the first frame update
    void Start()
    {
        _target = GameManager.Instance.player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (nextChargeTime < Time.time)
        {
            LookAt2D(transform, _target.transform.position);
            _lockOn = true;
            _destination = _target.transform.position + (_target.transform.position - transform.position) * overshoot;
            nextChargeTime = Time.time + chargeRate;    
        }
        
        if (_lockOn)
        {
            if (Vector2.Distance(transform.position, _destination) > stopDistance)
                transform.position = Vector2.MoveTowards(transform.position, _destination, speed * Time.deltaTime);
            else
            {
                _lockOn = false;
            }
        }
    }

    private static void LookAt2D(Transform transform, Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
}
