using UnityEngine;

namespace LadderUpDown
{
    public class LadderMoveScript : MonoBehaviour
    {
        private bool inside = false;
        public float speedUpDown = 3.2f;
        public Transform playerTransform; // Use the player's transform instead of ThirdPersonController
        public Animator animator;

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("Ladder"))
            {
                inside = true;
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.gameObject.CompareTag("Ladder"))
            {
                inside = false;
                if (animator != null)
                {
                    animator.SetBool("Climbing", false); // Stop climbing animation
                }
            }
        }

        private void Update()
        {
            if (inside)
            {
                float verticalInput = Input.GetAxis("Vertical");

                if (verticalInput > 0f)
                {
                    playerTransform.position += Vector3.up * Time.deltaTime * speedUpDown;
                    if (animator != null)
                    {
                        animator.SetBool("ClimbingUp", true); // Play climb up animation
                        animator.SetBool("ClimbingDown", false); // Ensure other climbing animation is off
                    }
                }
                else if (verticalInput < 0f)
                {
                    playerTransform.position += Vector3.down * Time.deltaTime * speedUpDown;
                    if (animator != null)
                    {
                        animator.SetBool("ClimbingDown", true); // Play climb down animation
                        animator.SetBool("ClimbingUp", false); // Ensure other climbing animation is off
                    }
                }
                else
                {
                    if (animator != null)
                    {
                        animator.SetBool("Climbing", false); // Stop climbing animation
                    }
                }
            }
        }
    }
}
