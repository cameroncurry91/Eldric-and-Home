using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToInteriorHouse : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadSceneAsync(0);
    }

}
