// Using the unity's engine in this script
using UnityEngine;

// Player Movement Handler class
public class PlayerMovementHandler : MonoBehaviour
{
    // Variables for speed, vector and rigidbody used in the code
    public float playerMovementSpeed;
    private Vector3 playerMovementVector;
    private Rigidbody PlayerRB;

    // Start function
    void Start()
    {
        // Define the player Movement Speed
        playerMovementSpeed = 2;

        // Define the Player Rigidbody by finding it from the components of the player (found inside inspector tab) (this means the script)
        PlayerRB = this.GetComponent<Rigidbody>();
    }

    // Update function
    private void Update()
    {
        // Define player Movement Vector with Horizontal and Vertical Input (Both defined in build settings)
        playerMovementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Normalize the player Movement Vector so the player doesnt go double speed when going diagonally
        playerMovementVector.Normalize();
    }

    // FixedUpdate function
    private void FixedUpdate()
    {
        // Move the player with rigidbody's velocity using player Movement Vector and player Movement Speed
        PlayerRB.velocity = playerMovementVector * playerMovementSpeed;
    }
}
