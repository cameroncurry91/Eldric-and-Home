using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : InteractionAnimator
{

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Implements IInteractable to open chest
    public override void Interact(Animator anim)
    {
        // Animate();
        Destroy(gameObject); // temp just deleting it
    }
}
