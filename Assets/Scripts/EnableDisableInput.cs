using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnableDisableInput : MonoBehaviour
{
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void EnableDisable(bool value)
    {
        playerInput.enabled = value;
    }
}
