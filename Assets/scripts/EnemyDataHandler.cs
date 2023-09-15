using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataHandler : MonoBehaviour
{
    public int health;
    public GameObject Enemy;
    void Start()
    {
        health = 2;
    }

    private void Update()
    {
        if (health <= 0)
        {
            EnemyDie();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void EnemyDie()
    {
        Destroy(Enemy);
    }
}
