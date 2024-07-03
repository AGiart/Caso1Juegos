using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawnPrefabs;

    [SerializeField]
    int maxSpawnAmount;

    [SerializeField]
    float spawnRange;

    [SerializeField]
    float spawnSafeRange;

    [SerializeField]
    Transform target;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for(int SpawnIndex = 0; SpawnIndex < maxSpawnAmount; SpawnIndex++)
        {
            Vector3 spawnPoint = Vector3.zero;
            while(Vector3.Distance(spawnPoint, Vector3.zero) < spawnSafeRange)
            {
                spawnPoint = GetSpawnPoint();
            }

            GameObject spawnPrefab = spawnPrefabs[Random.Range(0, spawnPrefabs.Length)];
            GameObject spawnObject = Instantiate(spawnPrefab, spawnPoint, Quaternion.identity);
            ChaseController chaseController = spawnObject.GetComponent<ChaseController>();
            chaseController.SetTarget(target);
            spawnObject.transform.parent = transform;
        }
    }

    private Vector3 GetSpawnPoint()
    {
        float x = Random.Range(-1.0F, 1.0F);
        float y = Random.Range(-1.0F, 1.0F);
        float z = Random.Range(-1.0F, 1.0F);

        Vector3 spawnPoint = new Vector3();

        if (spawnPoint.magnitude > 1.0F)
        {
            spawnPoint.Normalize();
        }

        spawnPoint *= spawnRange;

        return spawnPoint;
    }
}
