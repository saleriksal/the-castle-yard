using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAiHandler : MonoBehaviour
{
    public Transform player;
    public Rigidbody RB;
    public float speed;
    private void Start()
    {
        speed = 2f;
        RB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
