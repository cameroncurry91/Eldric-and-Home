using UnityEngine;

public interface IInteractable
{
    void Interact(Animator anim);
    bool InUse { get; set; }

}
