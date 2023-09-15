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

            int spawnPointX = Random.Range(-20, 20);
            int spawnPointZ = Random.Range(-20, 20);
            

            Vector3 spawnPos = new Vector3(spawnPointX, 0, spawnPointZ);

            if (Vector3.Distance(spawnPos, Player.transform.position))
            {
                Instantiate(Enemy, spawnPos, Quaternion.identity);
            }
        }
    }
}
