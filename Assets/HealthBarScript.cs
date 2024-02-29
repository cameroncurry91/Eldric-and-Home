using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider Slider;

    public void SetMaxHealth(int Health)
    {
        Slider.maxValue = Health;
        Slider.value = Health;

    
    }
    public void Sethealth(int Health)

    {
        Slider.value = Health;
    
    }

    public void TakeDamage(int amount)
    {
        Slider.maxValue -= amount;
        if (Slider.maxValue <= 0)
        {
            Destroy(gameObject);
        }
    
    }
    
}
