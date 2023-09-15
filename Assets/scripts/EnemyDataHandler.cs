using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataHandler : MonoBehaviour
{
    public int health;
    public GameObject Enemy;
    public GameObject particlePrefab;
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

        GameObject particleSystemObj = Instantiate(particlePrefab, gameObject.transform.position, Quaternion.identity);

        ParticleSystem particleSystem = particleSystemObj.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            Destroy(particleSystemObj, particleSystem.main.duration);
        }
    }
}
