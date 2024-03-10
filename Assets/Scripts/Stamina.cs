using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class Stamina : MonoBehaviour
{
    public Slider slider;
    private HeartScript health;
    private StarterAssetsInputs inputs;
    private Coroutine runningCoroutine;
    private Coroutine staminaUpCoroutine;

    public int stamina = 100;
    [SerializeField]
    private float staminaCooldown = 6f;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HeartScript>();
        inputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputs != null && inputs.sprint && runningCoroutine == null && health.isAlive == true)
        {
            runningCoroutine = StartCoroutine(StaminaDown());
        }

        SetStaminaSlider();
        
        if(stamina < 100 && staminaCooldown > 0 && inputs.sprint == false && staminaUpCoroutine == null && health.isAlive == true)
        {
            staminaCooldown -= Time.deltaTime;
        }

        if(stamina < 100 && inputs.sprint == false && staminaCooldown <= 0 && staminaUpCoroutine == null && health.isAlive == true)
        {
            staminaUpCoroutine = StartCoroutine(StaminaUp());
        }
    }

    private void SetStaminaSlider()
    {
        if(stamina < 0) stamina = 0;

        if (slider != null && slider.value != stamina)
        {
            slider.value = stamina;
        }
    }

    IEnumerator StaminaDown()
    {
        while(inputs.sprint && stamina > 0 && health.isAlive == true)
        {
            staminaCooldown = 10;
            stamina -= 1;
            yield return new WaitForSeconds(.1f);

        }
        runningCoroutine = null;
    }

    IEnumerator StaminaUp()
    {
        while (inputs.sprint == false && stamina < 100 && health.isAlive == true)
        {
            stamina += 1;
            yield return new WaitForSeconds(.5f);

        }
        staminaCooldown = 10;
        staminaUpCoroutine = null;
    }

    public void StaminaDown(int staminaToLose)
    {
        stamina -= staminaToLose;
    }
}
