using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    GameObject QuitButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void SaveQuit()
    {
        EventSystem.current.SetSelectedGameObject(QuitButton);
        Cursor.lockState = CursorLockMode.Locked;
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    // Method to restart the current scene
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

