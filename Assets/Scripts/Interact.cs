using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private Animator _anim;
    [SerializeField]
    private bool interacting;
    public GameObject contextPrompt;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            contextPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable") && interacting)
        {
            other.GetComponent<IInteractable>().Interact(_anim);
            interacting = false;
            Debug.Log("Times interacted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            contextPrompt.SetActive(false);
            other.GetComponent<IInteractable>().InUse = false;
        }
    }

    public void OnInteract(InputValue value)
    {
        interacting = value.isPressed;
    }
}
