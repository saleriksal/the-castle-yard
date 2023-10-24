using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAiHandler : MonoBehaviour
{
    public Transform player;
    public Rigidbody RB;
    public float speed;
    public bool acceptDamage = true;
    public GameObject GameManager;

    private void Start()
    {
        speed = 2f;
        RB = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
        GameManager = GameObject.FindWithTag("GameManager");
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.LookAt(player);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && acceptDamage)
        {
            acceptDamage = false;
            collision.gameObject.GetComponent<PlayerDataHandler>().PlayerDamageTaken(1);
            GameManager.GetComponent<GameManager>().enemiesDead++;
            Destroy(this.gameObject);
        }
    }
}