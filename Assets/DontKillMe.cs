using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Ensure that only one instance of MainCamera exists
    private static MainCamera instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this instance as the singleton instance
            instance = this;
            // Mark this GameObject to persist between scene transitions
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this duplicate GameObject
            Destroy(gameObject);
        }

        // Check if there's no camera in the scene
        if (Camera.main == null)
        {
            // Create a new camera GameObject
            GameObject newCamera = new GameObject("Main Camera");
            // Add Camera component to the new camera GameObject
            newCamera.AddComponent<Camera>();
        }
    }

    // Your other camera-related methods can be added here
}

