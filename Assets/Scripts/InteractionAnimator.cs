using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAnimator : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    protected void Animate()
    {
        anim.SetTrigger("Interact");
    }
}
