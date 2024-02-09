using UnityEngine;

public class Triggersleep : MonoBehaviour
{
    public Animator sleepANIMATION; // Reference to the Animator component

    // This method is called when another collider enters the trigger area
    void OnTriggerEnter(Collider triggersleep)
    {
        // Check if the collider belongs to the GameObject you want to trigger the animation on
        if (triggersleep.CompareTag("triggertest"))
        {
            // Trigger the animation by setting a parameter in the Animator Controller
            sleepANIMATION.SetTrigger("sleepANIMATION");
        }
    }
}

