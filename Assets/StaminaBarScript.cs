using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarScript : MonoBehaviour
{
    public Slider StaminaBar;

    public void SetMaxStamina(int Stamina)
    {
        StaminaBar.maxValue = Stamina;
        StaminaBar.value = Stamina;


    }
    public void SetStamina(int Stamina)

    {
        StaminaBar.value = Stamina;

    }

}


