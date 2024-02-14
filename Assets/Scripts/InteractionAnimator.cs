using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAnimator : MonoBehaviour, IInteractable
{
    public bool InUse { get; set; } // Property of IInteractable to see if in use
    protected Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(InUse == false && anim !=null && anim.GetBool("Interact") == true)
        {
            EndAnimate();
        }
    }

    // Animates object on interaction
    protected void Animate()
    {
        if(anim != null)
            anim.SetBool("Interact", true);
    }

    protected void EndAnimate()
    {
        if (anim != null)
            anim.SetBool("Interact", false);
    }

    // Implements Interact
    public virtual void Interact(Animator anim)
    {
        Animate();
        
    }
}
