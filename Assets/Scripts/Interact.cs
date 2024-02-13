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
        if (other.CompareTag("Interactable"))
        {
            contextPrompt.SetActive(true); // Enables context prompt
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable") && interacting)
        {
            other.GetComponent<IInteractable>().Interact(_anim); // Calls interact method on object and passes in anim 
            interacting = false;

            if (other.name == "Chest" || other.name == "Mailbox") contextPrompt.SetActive(false); // Disable context menu

            if(other.name == "Bed") // Set character height to 0
            {
                GetComponent<CharacterController>().height = 0;
                GetComponent<EnableDisableInput>().EnableDisable(false);
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
