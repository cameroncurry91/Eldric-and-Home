using UnityEngine;

// Interface script for interacting with anything, implement in a script on that object
public interface IInteractable
{
    void Interact(Animator anim); // Method to call on any object to perform the action
    bool InUse { get; set; } // Checks if object is in use

}
