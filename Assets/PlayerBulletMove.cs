using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float _decayTime = 2f;
    [SerializeField] public float speed = 5f;
    private Vector3 _destination;
    private bool _destSet = false; 
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_destSet)
        {
            Vector3 mousePos = GETMousePosition();
            _destination = mousePos + (mousePos - transform.position) * 10;
            LookAt2D(transform, _destination);
            _destSet = true;
            Destroy(gameObject,_decayTime);
        }
        transform.position = Vector2.MoveTowards(transform.position, _destination, speed * Time.deltaTime);
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
}
