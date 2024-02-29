using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to inflict on the player

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player GameObject
            HealthBarScript playerHealth = collision.collider.GetComponent<HealthBarScript>();

            if (playerHealth != null)
            {
                // Inflict damage on the player
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
