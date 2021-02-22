using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int randomSpawnpoint, randomMonster;
    private float time = 1.5f;
    private float min_rep = 1f;
    private float max_rep = 5f;

    public static bool spawnAllowed;

    private void Start()
    {
        InvokeRepeating("SpawnMonster", time, Random.Range(min_rep, max_rep));
    }
    void Update()
    {
        spawnAllowed = true;      
    }

    void SpawnMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnpoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonster], spawnPoints[randomSpawnpoint].position, Quaternion.identity);
        }
    }
}
