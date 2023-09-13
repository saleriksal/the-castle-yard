using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    public float playerMovementSpeed;
    private Vector3 playerMovementVector;
    private Rigidbody PlayerRB;
    void Start()
    {
        playerMovementSpeed = 3;
        PlayerRB = this.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        playerMovementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        MovePlayer(playerMovementVector);
    }
    private void MovePlayer(Vector3 direction)
    {
        PlayerRB.velocity = direction * playerMovementSpeed;
    }
}
