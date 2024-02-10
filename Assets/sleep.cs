using UnityEngine;

public class Sleep : MonoBehaviour
{
    private Animator AnimationController_Jamo;

    void Start()
    {
        // Get the Animator component attached to the character
        AnimationController_Jamo = GetComponent<Animator>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Bed"))
        {
            // Play the falling asleep animation
            AnimationController_Jamo.SetTrigger("sleep");
        }
    }
}
