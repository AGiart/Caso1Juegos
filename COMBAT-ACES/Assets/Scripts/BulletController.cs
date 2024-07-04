using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    LayerMask targetMask;

    [SerializeField]
    float speed;

    [SerializeField]
    Transform _shooter;


    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy") || _shooter.CompareTag("Boss") && collision.collider.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

        }else if (collision.collider.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<HealthController>().takeDamage();
        }
        Destroy(gameObject);
    }

    public void SetTarget(Transform shooter)
    {
        _shooter = shooter;

    }
}
