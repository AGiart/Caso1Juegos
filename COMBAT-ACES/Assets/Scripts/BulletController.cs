using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    LayerMask targetMask;

    [SerializeField]
    float speed;


    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = Vector3.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((targetMask & (1 << collision.gameObject.layer)) != 0)
        {
            Destroy(collision.gameObject);
            
        }
        Destroy(gameObject);
    }
}
