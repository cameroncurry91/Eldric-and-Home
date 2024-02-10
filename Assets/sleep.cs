using UnityEngine;

public class Sleep : MonoBehaviour, IInteractable
{
    void Start()
    {
    }

    // Implements IInteractable to make player sleep
    public void Interact(Animator anim)
    {
        anim.SetTrigger("sleep");
        Debug.Log("Sleeping zzz");
    }
}
