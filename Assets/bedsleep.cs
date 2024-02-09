using UnityEngine;

public class Bedimation : MonoBehaviour
{

    // Reference to the Animator component
    Animator animator;

    // Collision detection
    Collision collision;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Set the trigger parameter to true
        animator.SetTrigger("TriggerAnimation");
    }
}
