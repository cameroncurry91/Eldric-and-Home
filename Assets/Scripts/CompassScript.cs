using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    Vector3 dir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir.z = player.eulerAngles.y;
        transform.localEulerAngles = dir;
    }
}
