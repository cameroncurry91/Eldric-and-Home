using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyEldric : MonoBehaviour
{
    // Reference to the player character GameObject
    public GameObject eldricPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure that the eldricPlayer reference is not null
        if (eldricPlayer != null)
        {
            // Destroy the player character GameObject
            Destroy(eldricPlayer);
        }
        else
        {
            Debug.LogWarning("Player character reference is null. Ensure that the player character is assigned in the inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: You can add additional behavior here if needed
    }

}
