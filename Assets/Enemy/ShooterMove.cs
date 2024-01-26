using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMove : MonoBehaviour
{
    private GameObject _target;
    public float speed = 1f;
    public float stopDistance = 10f;
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
                transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
            else if (Vector2.Distance(transform.position, _target.transform.position) < stopDistance*0.75f)
                transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, -speed * Time.deltaTime);
            else
                transform.position = Vector2.MoveTowards(transform.position, (transform.position + transform.right * flightDirection - transform.forward), speed * Time.deltaTime);

            if (nextFlightChange < Time.time)
            {
                flightDirection *= -1;
                flightChangeRate = Random.Range(1f, 10f);
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
