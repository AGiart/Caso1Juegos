using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireController : MonoBehaviour
{
    [SerializeField]
    Transform[] firePoints;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject bulletEnemyPrefab;

    [SerializeField]
    float fireDelay;

    [SerializeField]
    float lifeTimeOut;

    float currentTime;

    [SerializeField]
    Transform _target;

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime < 0.0F)
        {
            currentTime = 0.0F;
        }

       if (Input.GetButtonDown("Fire1") && gameObject.CompareTag("Player")) 
        {
            if(currentTime > 0.0F) 
            {
                return;
            }
            foreach (Transform firepoint in firePoints) 
            {
                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                bullet.GetComponent<BulletController>().SetTarget(gameObject.transform);
                Destroy(bullet.gameObject, lifeTimeOut);
            }

            currentTime = fireDelay;

        }

       if(gameObject.CompareTag("Boss") && gameObject.GetComponent<ChaseController>().enMovimiento == false)
        {
            if (currentTime > 0.0F)
            {
                return;
            }
            foreach (Transform firepoint in firePoints)
            {
                GameObject Enemybullet = Instantiate(bulletEnemyPrefab, firepoint.position, firepoint.rotation);
                Enemybullet.GetComponent<BulletController>().SetTarget(gameObject.transform);
                Destroy(Enemybullet.gameObject, lifeTimeOut);
            }

            currentTime = fireDelay;
        }
    }




}
