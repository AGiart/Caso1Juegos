using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChaseController : MonoBehaviour
{

    Transform _target;

    [SerializeField]
    float speed;

    [SerializeField]
    float stopDistance;

    public bool enMovimiento;


    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
  
    }
    public void SetTarget(Transform target)
    {
        _target = target;
        
    }

    //chase target (No retreat) - 50 puntos

    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        
        float distance = Vector3.Distance(_rigidbody.position, _target.position);

        if (_rigidbody.CompareTag("Enemy"))
        {
            _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, _target.position, speed * Time.fixedDeltaTime); 
        }
        else if (_rigidbody.CompareTag("Boss"))
        {

            if (distance > stopDistance)
            {
                enMovimiento = true;
                _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, _target.position, speed * Time.fixedDeltaTime);
            }
            
            else if(distance <= stopDistance) 
            { 
                enMovimiento=false;
            }
        }

        transform.LookAt(_target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    // look at target: 10 puntos
    // move to target: 40 puntos
}
