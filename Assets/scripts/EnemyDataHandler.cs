using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataHandler : MonoBehaviour
{
    public AudioClip[] dmg;
    private AudioClip dmgClip;
    public int health;
    public GameObject Enemy;
    public GameObject particlePrefab;
    public GameObject player;
    public GameObject[] powerups;
    public GameObject powerup;
    public AudioSource dmgSound;
    private bool canDestroy = false;
    private bool canDie = true;
    public GameObject GameManager;
    void Start()
    {
        health = 2;
        player = GameObject.FindWithTag("Player");
        dmgSound = gameObject.GetComponent<AudioSource>();
        GameManager = GameObject.FindWithTag("GameManager");
    }

    private void Update()
    {
        if (health <= 0)
        {
            if (canDie)
            {
                Enemy.GetComponent<EnemyAiHandler>().acceptDamage = false;
                EnemyDie();
            }
            
            if (!dmgSound.isPlaying && canDestroy)
            {
                Destroy(Enemy);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void EnemyDie()
    {
        canDie = false;
        int chance = Random.Range(0, 10);
        if (chance == 5)
        {
            int randompower = Random.Range(0, powerups.Length);
            powerup = powerups[randompower];
            Instantiate(powerup, Enemy.transform.position, Quaternion.identity);
        }
        int index = Random.Range(0, dmg.Length);
        dmgClip = dmg[index];
        dmgSound.clip = dmgClip;
        dmgSound.Play();
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
        Enemy.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        GameObject particleSystemObj = Instantiate(particlePrefab, gameObject.transform.position, Quaternion.identity);

        ParticleSystem particleSystem = particleSystemObj.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            Destroy(particleSystemObj, particleSystem.main.duration);
        }
        player.GetComponent<PlayerDataHandler>().playerKills++;
        GameManager.GetComponent<GameManager>().enemiesDead++;
        if (dmgSound.isPlaying)
        {
            canDestroy = true;
        }
    }
}
