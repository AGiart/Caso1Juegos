using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawnPrefabs;

    [SerializeField]
    GameObject[] spawnBossPrefabs;



    [SerializeField]
    int maxSpawnAmount;

    [SerializeField]
    float spawnRange;

    [SerializeField]
    float spawnSafeRange;

    [SerializeField]
    Transform target;

    public float actualNumEnemy;

    public bool posibleBoss;

    private GameObject[] enemiesList;

    private void Start()
    {
        Spawn();
        posibleBoss = true;
    }
    private void Update()
    {
        enemiesList = GameObject.FindGameObjectsWithTag("Enemy");
        actualNumEnemy = enemiesList.Length;
        spawnBoss();

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

    private void spawnBoss()
    {
        if(actualNumEnemy == 0 && GameObject.FindGameObjectsWithTag("Boss").Length < 1 && posibleBoss)
        {
            Vector3 spawnPoint = Vector3.zero;
            while (Vector3.Distance(spawnPoint, Vector3.zero) < spawnSafeRange)
            {
                spawnPoint = GetSpawnPoint();

            }

            GameObject spawnBossPrefab = spawnBossPrefabs[Random.Range(0, spawnBossPrefabs.Length)];
            GameObject spawnBossObject = Instantiate(spawnBossPrefab, spawnPoint, Quaternion.identity);
            ChaseController chaseController = spawnBossObject.GetComponent<ChaseController>();
            chaseController.SetTarget(target);
            spawnBossObject.transform.parent = transform;
            posibleBoss = false;
        }
    }

    private Vector3 GetSpawnPoint()
    {
        float x = Random.Range(-1.0F, 1.0F);
        float y = Random.Range(-1.0F, 1.0F);
        float z = Random.Range(-1.0F, 1.0F);

        Vector3 spawnPoint = new Vector3(x,y,z);

        if (spawnPoint.magnitude > 1.0F)
        {
            spawnPoint.Normalize();
        }

        spawnPoint *= spawnRange;

        return spawnPoint;
    }
}
