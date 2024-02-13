using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sleep : MonoBehaviour, IInteractable
{
    public bool InUse { get; set; } // Property of IInteractable to see if in use
    public GameObject savePanel;
    public GameObject yesButton;
    private Animator lastAnim;

    private void Update()
    {
    
    }

    // Implements IInteractable to make player sleep
    public void Interact(Animator anim)
    {
        lastAnim = anim;
        if (InUse) { return; } // Already in use don't trigger again

        anim.SetBool("Sleep", true); // Transition to Sleep Animation

        InUse = true; // Set to in use
        savePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(yesButton);
    }

    public void GetUp()
    {
        InUse = false;
        lastAnim.SetBool("Sleep", false);
    }
    
    public void SaveQuit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
