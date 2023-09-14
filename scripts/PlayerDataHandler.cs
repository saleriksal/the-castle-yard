using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    public int playerHealth;
    public int playerKills;
    public int damageDealt;
    public int deathCount;
    public Vector3 playerCurrentPosition;
    public Quaternion playerCurrentRotation;
    public GameObject player;

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
            PlayerDeath();
        }
    }

    // Player takes damage
    void PlayerDamageTaken(int damage)
    {
        playerHealth -= damage;
    }

    // Player dies
    void PlayerDeath()
    {
        deathCount++;
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
