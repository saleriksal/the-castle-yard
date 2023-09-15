using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhysicController : MonoBehaviour
{
    public int health;
    public GameObject particlePrefab;
    private void Start()
    {
        health = 3;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);

            GameObject particleSystemObj = Instantiate(particlePrefab, gameObject.transform.position, Quaternion.identity);

            ParticleSystem particleSystem = particleSystemObj.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                Destroy(particleSystemObj, particleSystem.main.duration);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
