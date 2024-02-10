using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public bool InUse { get; set; } // Property of IInteractable to see if in use

    void Start()
    {
    }

    // Implements IInteractable to open chest
    public void Interact(Animator anim)
    {
        Destroy(gameObject); // temp just deleting it
    }
}
