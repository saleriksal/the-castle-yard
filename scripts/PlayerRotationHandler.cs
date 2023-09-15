// Using the unity's engine
using UnityEngine;

// Player Rotation Handler class
public class PlayerRotationHandler : MonoBehaviour
{
    // Variables
    private Camera mainCamera;

    // Start function
    void Start()
    {
        // Set main camera
        mainCamera = Camera.main;
    }

    // Update function
    void Update()
    {
        // Get mouse position on screen
        Vector3 mousePosition = Input.mousePosition;

        // Convert mouse position to world coordinates
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.transform.position.y));

        // Calculate the direction from character to mouse
        Vector3 lookDirection = worldMousePosition - transform.position;
        lookDirection.y = 0f;

        // Turn the player with quaternion
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);

        // Rotate the player using y axis towards the mouse
        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
    }
}
