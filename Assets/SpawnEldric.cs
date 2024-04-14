using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEldric : MonoBehaviour
{
    public GameObject eldric;
    static bool spawnedEldric; 
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(eldric);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
