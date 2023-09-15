using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnHandler : MonoBehaviour
{
    public GameObject Enemy;
    public float delay;
    public float nextSpawn;
    public GameObject Player;
    void Start()
    {
        delay = 2;
        nextSpawn = Time.time + delay;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + delay;

            GetPositions();
        }
    }
    void GetPositions()
    {
        int spawnPointX = Random.Range(-20, 20);
        int spawnPointZ = Random.Range(-20, 20);

        Vector3 playerPos = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);

        Vector3 spawnPos = new Vector3(spawnPointX, 0, spawnPointZ);

        float spawnDist = Vector3.Distance(spawnPos, playerPos);

        SpawnEnemy(spawnDist, spawnPos);

    }
    void SpawnEnemy(float spawnDist, Vector3 spawnPos)
    {
        if (spawnDist > 10)
        {
            Instantiate(Enemy, spawnPos, Quaternion.identity);
        }
        else
        {
            GetPositions();
        }
        
    }
}
