using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovment : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Player;
    Vector3 OffSet;

void Start()
    {
        Camera = gameObject;
        OffSet = Camera.transform.position - Player.transform.position;
    }

void FixedUpdate()
    {
        Camera.transform.position = Player.transform.position + OffSet;
    }
}
