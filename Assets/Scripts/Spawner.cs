using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int minInterval = 5;
    public float range = 15;
    public int maxSpawns = 1000;
    int currentSpawnCount = 0;
    float spawnDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", minInterval, range);
    }

    public GameObject enemy;

    void Spawn()
    {
        if (currentSpawnCount < maxSpawns)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            currentSpawnCount++;
        }
    }
}
