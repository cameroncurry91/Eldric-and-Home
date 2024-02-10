using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    void Start()
    {
    }

    // Implements IInteractable to make player sleep
    public void Interact(Animator anim)
    {
        Destroy(gameObject);
        Debug.Log("Opening Chest!");
    }
}
