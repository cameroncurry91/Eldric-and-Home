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
        _anim = GetComponent<Animator>(); // Gets animator
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && other.GetComponent<IInteractable>().InUse == false)
        {
            contextPrompt.SetActive(true); // Enables context prompt
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable") && interacting)
        {
            IInteractable interactable = other.GetComponent<IInteractable>();
            interactable.Interact(_anim); // Calls interact method on object and passes in anim 
            interacting = false;

            contextPrompt.SetActive(false); // Disable context menu

            if(other.name == "Bed" || other.name == "Cook")
            {
                GetComponent<EnableDisableInput>().EnableDisable(false);
                contextPrompt.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            contextPrompt.SetActive(false); // Disables Context Prompt
            other.GetComponent<IInteractable>().InUse = false;

        }
    }

    /// <summary>
    /// Checks if player is pressing interact action button
    /// </summary>
    /// <param name="value"></param>
    public void OnInteract(InputValue value)
    {
        interacting = value.isPressed;
    }
}
