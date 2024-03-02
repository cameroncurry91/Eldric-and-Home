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
        if (Health <= 0)
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

