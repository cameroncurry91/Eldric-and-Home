using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    // Ensure that only one instance of MainCamera exists
    private static PlayerFollowCamera instance;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
