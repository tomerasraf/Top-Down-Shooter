using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyPrefab;
    public float spawnDealy = 5f;
    private float tempSpawnDealy;
    public float endOfSpawning = 60f;
    private float tempEndOfSpawning;
    public int amountOfEnemys;

    public static int enemyCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        tempSpawnDealy = spawnDealy;
        tempEndOfSpawning = endOfSpawning;
    }

    // Update is called once per frame
    void Update()
    {
        tempEndOfSpawning -= Time.deltaTime;
        tempSpawnDealy -= Time.deltaTime;

        if (tempEndOfSpawning >= 0f)
        {
            if (tempSpawnDealy <= 0f)
            {
                SpawnEnemy();
                tempSpawnDealy = spawnDealy;
            }
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < amountOfEnemys; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemyCounter++;
        }
    }
}
