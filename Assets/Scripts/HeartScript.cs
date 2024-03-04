using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
    public float regenDelay = 5f; // Delay before regeneration starts after taking damage
    public float regenRate = .5f; // Health regenerated per second
    public bool isRegenerating = false;
    public float Health; // Now a floating-point value
    public int numOfHearts; // Represents the total number of heart icon slots
    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public Sprite HalfHeart;
    public Sprite EightyPercentHeart;
    public Sprite TwentyPercentHeart;
    public Animator Temp; // Reference to the Animator component

    // Fall damage variables
    float distanceToGround = 1;
    public float fallThreshold = 1f; // Minimum fall height to receive damage
    private float highestPoint; // Tracks the highest point during a fall
    private bool isGrounded; // Tracks if the player is on the ground

    private void Start()
    {
        {
            // Initialize or validate playerAnimator reference
            if (Temp == null)
            {
                Temp = GetComponent<Animator>();
                if (Temp == null)
                {
                    Debug.LogWarning("Animator component not found on the player!");
                }
            }
        }
        UpdateHearts();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            HeartScript playerHealth = collision.collider.GetComponent<HeartScript>();

            if (playerHealth != null)
            {
                // This call will now also handle checking and starting regeneration
                playerHealth.AdjustHealth(-1); // Assuming -1 is the damage amount
            }
        }
    }
    private void Update()
    {
        CheckGroundStatus();
    }
    private void CheckGroundStatus()
    {

        float raycastLength = 1f; // Slightly longer than distanceToGround to ensure detection
        LayerMask groundLayer = LayerMask.GetMask("Ground"); // Make sure your ground objects are in a layer named "Ground" or adjust this accordingly

        // Cast a ray straight down.
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, out hit, raycastLength, groundLayer);


        if (!isGrounded)
        {
            highestPoint = Mathf.Max(highestPoint, transform.position.y);
        }
        else if (highestPoint > 0)
        {
            float fallDistance = highestPoint - transform.position.y;
            if (fallDistance > fallThreshold)
            {
                AdjustHealth(-Mathf.Infinity); // Apply fatal fall damage
                if (Health <= 0)
                {
                    PlayDeathAnimation(); // Ensure death animation plays after fatal damage
                }
            }
            highestPoint = 0;
        }
    }


    public void AdjustHealth(float amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health, 0, numOfHearts * 2f); // Use floating-point for max health
        UpdateHearts();

        // If taking damage, potentially start regeneration with a delay
        if (amount < 0 && !isRegenerating)
        {
            StartCoroutine(DelayedRegeneration(regenDelay));
        }

        // Check if health has dropped to 0 and play death animation
        if (Health <= 0 && Temp != null)
        {
            
            PlayDeathAnimation();
        }
    }

    void PlayDeathAnimation()
    {
        if (Temp != null)
        {
            Temp.SetBool("IsDead", true);
            // Optionally disable player movement and other input responses here
        }
    }


    private IEnumerator DelayedRegeneration(float delay)
    {
        isRegenerating = true;
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Start the regeneration process
        while (Health < numOfHearts * 2)
        {
            AdjustHealth(regenRate * Time.deltaTime);
            yield return null; // Wait until the next frame
        }

        isRegenerating = false; // Stop regenerating when max health is reached
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                Hearts[i].enabled = true;
                float heartHealth = Health - (i * 2f);

                // Determine sprite based on heartHealth
                if (heartHealth > 1.5)
                {
                    Hearts[i].sprite = FullHeart;
                }
                else if (heartHealth > 1)
                {
                    Hearts[i].sprite = EightyPercentHeart;
                }
                else if (heartHealth > 0.5)
                {
                    Hearts[i].sprite = HalfHeart;
                }
                else if (heartHealth > 0)
                {
                    Hearts[i].sprite = TwentyPercentHeart;
                }
                else
                {
                    Hearts[i].sprite = EmptyHeart;
                }
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }
    }
}

