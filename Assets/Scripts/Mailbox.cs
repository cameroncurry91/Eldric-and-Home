using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : InteractionAnimator
{

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (InUse == false && anim.GetBool("Interact") == true)
        {
            EndAnimate();
        }
    }

    public override void Interact(Animator anim)
    {
        InUse = true;
        Animate();
        //Destroy(gameObject); // temp just deleting it
    }
}
