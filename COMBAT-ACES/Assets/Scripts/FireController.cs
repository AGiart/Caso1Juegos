using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField]
    Transform[] firePoints;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float fireDelay;

    [SerializeField]
    float lifeTimeOut;

    float currentTime;


    private void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime < 0.0F)
        {
            currentTime = 0.0F;
        }

       if (Input.GetButtonDown("Fire1")) 
        {
            if(currentTime > 0.0F) 
            {
                return;
            }
            foreach (Transform firepoint in firePoints) 
            {
                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                Destroy(bullet.gameObject, lifeTimeOut);
            }

            currentTime = fireDelay;

        }
    }

    
}
