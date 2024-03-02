using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private CanvasGroup _interactableUI;
    private bool _PlayerWithinRange;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _interactableUI.gameObject.SetActive(true);
            LeanTween.cancel(_interactableUI.gameObject);
            LeanTween.alphaCanvas(_interactableUI, 1, 1);
            _PlayerWithinRange = true;
        }
    }

    private void Update()
    {
        if (_PlayerWithinRange && Input.GetKeyUp(KeyCode.E))
        {

            Activate();
        
        }


    }
    public virtual void Activate()
    {
        _interactableUI.gameObject.SetActive(false);

    }

    public virtual void Deactivate()
    { 
    
    
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _PlayerWithinRange = false;

            LeanTween.alphaCanvas(_interactableUI, 0, 1)
                .setOnComplete(UIHide);
        }
    }

    private void UIHide()
    {
        

    }
}