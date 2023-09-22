using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    public GameObject Enemy;
    public float delay;
    public float nextSpawn;
    public GameObject Player;
    private bool SpawnEnemys = false;
    private int SpawnvaweCount;
    int timesOG;
    int times;
    void Start()
    {
        delay = 5;
        nextSpawn = Time.time + delay;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnEnemys)
        {
            if (SpawnvaweCount > 0)
            {
                if (Time.time > nextSpawn)
                {
                    nextSpawn = Time.time + delay;

                    GetPositions();
                    SpawnvaweCount--;
                }
            }
        }
    }

    public void StartVaweSpawning(int vaweCount, int enemyCount)
    {
        SpawnEnemys = true;
        SpawnvaweCount = vaweCount;
        timesOG = enemyCount;
        times = timesOG;
    }

    void GetPositions()
    {
        if (times > 0)
        {
            int spawnPointX = Random.Range(-20, 20);
            int spawnPointZ = Random.Range(-20, 20);

            Vector3 playerPos = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);

            Vector3 spawnPos = new Vector3(spawnPointX, 1.5f, spawnPointZ);

            float spawnDist = Vector3.Distance(spawnPos, playerPos);

            SpawnEnemy(spawnDist, spawnPos);
        }
        else
        {
            times = timesOG;
        }
    }
    void SpawnEnemy(float spawnDist, Vector3 spawnPos)
    {
        if (spawnDist > 10)
        {
            times--;
            Instantiate(Enemy, spawnPos, Quaternion.identity);
            GetPositions();
        }
        else
        {
            GetPositions();
        }
        
    }
}
