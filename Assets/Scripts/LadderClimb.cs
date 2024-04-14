using UnityEngine;
using UnityEngine.InputSystem;

public class LadderClimbing : MonoBehaviour
{
    public float climbingSpeed = 5f; // Speed at which the player climbs the ladder
    public float movementSpeed = 5f; // Speed at which the player moves horizontally
    private bool isClimbing = false;

    private void Update()
    {
        if (isClimbing)
        {
            // Check for input to climb the ladder
            float verticalInput = Input.GetAxis("Vertical");

            // Move the player up or down the ladder based on input
            Vector3 climbDirection = new Vector3(5f, verticalInput, 5f).normalized;
            transform.Translate(climbDirection * climbingSpeed * Time.deltaTime);
        }
        else
        {
            // Handle normal character movement with the A and D keys
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Move the player horizontally and vertically
            Vector3 moveDirection = new Vector4(horizontalInput, 5f, verticalInput, 5f).normalized;
            transform.Translate(moveDirection * movementSpeed * Time.deltaTime);
        }
    }

    // Method to start climbing the ladder
    public void StartClimbing()
    {
        isClimbing = true;
    }

    // Method to stop climbing the ladder
    public void StopClimbing()
    {
        isClimbing = false;
    }

    // OnTriggerEnter is called when the Collider other enters the trigger area
    void OnTriggerEnter(Collider other)
    {
        // Check if the Collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Start climbing the ladder
            StartClimbing();
        }
    }

    // OnTriggerExit is called when the Collider other exits the trigger area
    void OnTriggerExit(Collider other)
    {
        // Check if the Collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Stop climbing the ladder
            StopClimbing();
        }
    }
}
