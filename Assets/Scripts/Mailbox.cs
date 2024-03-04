using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

public class Mailbox : InteractionAnimator
{
    public GameObject letterPanel;
    public GameObject closeButton;
    public TextMeshProUGUI closeLabel;
    public EnableDisableInput playerInput;
    public StarterAssetsInputs inputs;

    void Start()
    {
        anim = GetComponent<Animator>();
#if UNITY_STANDALONE
        closeLabel.text = "p.s. Press 'Enter' to put letter away";
#elif UNITY_XBOXONE
        closeLabel.text = "p.s. Press 'A' to put letter away";
#elif UNITY_PS4
        closeLabel.text = "p.s. Press 'X' to put letter away";
#endif
    }

    private void Update()
    {
        if (InUse == false && anim.GetBool("Interact") == true)
        {
            EndAnimate();
        }

        if(InUse && EventSystem.current.currentSelectedGameObject != closeButton)
        {
            EventSystem.current.SetSelectedGameObject(closeButton);
        }
    }

    public override void Interact(Animator anim)
    {
        if (InUse == false)
        {
            // Set to in use and animate
            InUse = true;
            Animate();

            // Show letter after opening mailbox
            Invoke(nameof(ShowLetter), 0.5f);

            // Disable Player Input
            playerInput.EnableDisable(false);
        }
    }

    private void ShowLetter()
    {
        // Enable Letter and Select Close button
        letterPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(closeButton);

        // Unlock Cursor
        inputs.cursorLocked = false;
        inputs.SetCursorState(inputs.cursorLocked);
    }

    public void CloseLetter()
    {
        // Close letter and end animation
        letterPanel.SetActive(false);
        EndAnimate();
        InUse = false;

        // Lock Cursor
        inputs.cursorLocked = true;
        inputs.SetCursorState(inputs.cursorLocked);

        // Enable Player Input
        playerInput.EnableDisable(true);
    }
}
