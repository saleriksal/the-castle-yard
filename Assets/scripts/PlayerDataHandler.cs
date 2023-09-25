using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    [Header("Player Data")]
    public int playerHealth;
    public int playerKills;
    public int damageDealt;
    public int deathCount;
    public Vector3 playerCurrentPosition;
    public Quaternion playerCurrentRotation;

    [Header("Player Sources")]
    public GameObject player;
    public AudioSource damageSound;
    public AudioSource gameOver;

    private float pitch;

    private bool canDie = true;

    // Start
    void Start()
    {
        playerHealth = 10;
        playerKills = 0;
        damageDealt = 0;
        deathCount = 0;
        player = this.gameObject;
    }

    // Update
    void Update()
    {
        playerCurrentPosition = player.transform.position;
        playerCurrentRotation = player.transform.rotation;

        if (playerHealth <= 0)
        {
            if (canDie)
            {
                canDie = false;
                PlayerDeath();
            }
        }
    }

    // Player takes damage
    public void PlayerDamageTaken(int damage)
    {
        pitch = Random.Range(0.9f, 1.1f);
        damageSound.pitch = pitch;
        damageSound.Play();
        playerHealth -= damage;
        player.GetComponentInChildren<GameGuiHandler>().withd -= 30;
    }
    public void PlayerHealTaken(int health)
    {
        pitch = Random.Range(0.9f, 1.1f);
        damageSound.pitch = pitch;
        damageSound.Play();
        playerHealth += health;
        player.GetComponentInChildren<GameGuiHandler>().withd += 30;
    }

    // Player dies
    void PlayerDeath()
    {
        gameOver.Play();
        deathCount++;
        Time.timeScale = 0;
    }

    // player gets kill
    void PlayerKill()
    {
        playerKills++;
    }

    // Player deals damage
    void DamageDealt(int damage)
    {
        damageDealt += damage;
    }
}
