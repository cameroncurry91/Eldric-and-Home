using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private static HUD instance;
    private void Awake()
    {
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
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
