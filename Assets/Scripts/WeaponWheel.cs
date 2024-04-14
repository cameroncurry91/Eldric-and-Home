using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponWheel : MonoBehaviour
{
    private bool isWheelActive;
    private bool toolEquipped;
    private GameObject weaponWheelUI;
    public GameObject[] tools;

    private void Start()
    {
        weaponWheelUI = GameObject.FindWithTag("WeaponWheel");
        toolEquipped = false;
        isWheelActive = false;
        weaponWheelUI.SetActive(isWheelActive);
    }

    public void OnWeaponWheel(InputValue context)
    {
        EnableDisableWheel();
    }

    public void EnableDisableWheel()
    {
        isWheelActive = !isWheelActive;
        weaponWheelUI.SetActive(isWheelActive);

        if(isWheelActive )
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void EnableDisableTool(int index)
    {
        foreach(GameObject tool in tools)
        {
            if(tool.activeInHierarchy) tool.SetActive(false);
        }

        if(toolEquipped == false)
        {
            tools[index].SetActive(true);
            toolEquipped = true;
        }
        else
        {
            tools[index].SetActive(false);
            toolEquipped = false;
        }
            

        EnableDisableWheel();
    }
}
