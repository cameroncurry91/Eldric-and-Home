using UnityEngine;
using System.Collections;

public class PlayerRoll : MonoBehaviour
{
    public float rollSpeed = 5f;
    public float rollDuration = 0.5f;

    private CharacterController characterController;
    private Animator animator;
    private bool isRolling = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleRollInput();
    }

    void HandleRollInput()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isRolling)
        {
            StartCoroutine(Roll());
        }
    }

    IEnumerator Roll()
    {
        isRolling = true;
        animator.SetBool("IsRolling", true); // Activate roll animation

        float startTime = Time.time;
        Vector3 rollDirection = transform.forward;

        while (Time.time < startTime + rollDuration)
        {
            characterController.SimpleMove(rollDirection * rollSpeed);
            yield return null;
        }

        isRolling = false;
        animator.SetBool("IsRolling", false); // Deactivate roll animation
    }
}
