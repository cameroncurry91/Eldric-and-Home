using UnityEngine;

public class Sleep : MonoBehaviour, IInteractable
{
    public bool InUse { get; set; } // Property of IInteractable to see if in use

    void Start()
    {
    }

    // Implements IInteractable to make player sleep
    public void Interact(Animator anim)
    {
        if (InUse) { return; } // Already in use don't trigger again

        anim.SetTrigger("sleep"); // Transition to Sleep Animation

        InUse = true; // Set to in use
    }
}
