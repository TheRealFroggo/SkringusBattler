using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    Camera cam;
    float Size;
    float Speed;
    float LifeSpan;

    private Vector3 _destination;
    private bool _destSet = false; 
    
    void Start()
    {
        cam = Camera.main;
        transform.localScale = new Vector3(Size, Size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_destSet)
        {
            Vector3 mousePos = GETMousePosition();
            _destination = mousePos + (mousePos - transform.position) * 9999;
            LookAt2D(transform, _destination);
            _destSet = true;
            Destroy(gameObject,LifeSpan);
        }
        transform.position = Vector2.MoveTowards(transform.position, _destination, Speed * Time.deltaTime);
    }

    public Vector3 GETMousePosition()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        var mousePosition = cam.ScreenToWorldPoint(screenMousePosition);
        return mousePosition;
    }
    
    private static void LookAt2D(Transform transform, Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void SetSize(float i)
    {
        Size = i;
    }

    public void SetSpeed(float i)
    {
        Speed = i;
    }

    public void SetLifeSpan(float i)
    {
        LifeSpan = i;
    }
}
