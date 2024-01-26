using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikerFollow : MonoBehaviour
{
    private GameObject _target;
    public float speed = 1f;
    public float stopDistance = 1f;
    public float flightDirection = 1f;
    
    private float nextFlightChange = 0;
    public float flightChangeRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            if (Vector2.Distance(transform.position, _target.transform.position) > stopDistance)
                transform.position = Vector2.MoveTowards(transform.position, _target.transform.position + transform.right * 3f * flightDirection, speed * Time.deltaTime);

            if (nextFlightChange < Time.time)
            {
                flightDirection *= -1;
                flightChangeRate = Random.Range(0.1f, 0.5f);
                nextFlightChange = Time.time + flightChangeRate;
            }
            
            LookAt2D(transform, _target.transform.position);
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
