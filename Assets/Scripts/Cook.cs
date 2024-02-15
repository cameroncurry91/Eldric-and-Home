using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cook : InteractionAnimator
{

    public PlayableDirector directorguydude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Interact(Animator anim)
    {
        // Animate();
        InUse = true;
        directorguydude.Play();
    }
}
