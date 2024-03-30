using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance;

    public object Instance { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy if another instance exists
        }
    }

    private void Start()
    {
        GameObject existingObject = GameObject.FindWithTag("Player");
        if (existingObject == null)
        {
            // Instantiate your object here
        }
    }
}
