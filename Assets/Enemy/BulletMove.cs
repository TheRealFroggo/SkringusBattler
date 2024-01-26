using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] public float speed = 5f;
    [SerializeField] private float _decayTime = 2f;

    private Vector3 _destination;
    private bool _destSet = false; 
    
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
            if (!_destSet)
            {
                _destination = _target.transform.position + (_target.transform.position - transform.position) * 10;
                LookAt2D(transform, _destination);
                _destSet = true;
                Destroy(gameObject,_decayTime);
            }
            transform.position = Vector2.MoveTowards(transform.position, _destination, speed * Time.deltaTime);
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
