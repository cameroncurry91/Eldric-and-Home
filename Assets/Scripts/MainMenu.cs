using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    GameObject QuitButton;

    public MainMenu(GameObject quitButton)
    {
        QuitButton = quitButton;
    }

    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI ProgressText; // Change type to TextMeshProUGUI

    // Method called when the player clicks the "Play" button
    public void PlayButtonClicked()
    {
        // Enable the loading canvas
        loadingScreen.SetActive(true);

        // Start an asynchronous operation to load the next scene
        StartCoroutine(LoadSceneAsyncWithProgress());
    }

    // Coroutine to asynchronously load the next scene
    IEnumerator LoadSceneAsyncWithProgress()
    {
        // Start loading the next scene in the background
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        // Don't allow the scene to activate until it's fully loaded
        operation.allowSceneActivation = false; // Prevent automatic scene activation

        // Wait until the next scene is fully loaded
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Progress until 90%
            progress += (operation.progress >= 0.9f) ? 0 : 0; // Add 1 when operation.progress reaches 0.9
            slider.value = progress;
            ProgressText.text = progress * 100f + "%";
            // Check if the load progress is >= 0.9f (scene is almost fully loaded)
            if (operation.progress >= 0.9f && progress >= 1f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    // Method called when the player clicks the "Quit" button
    public void QuitButtonClicked()
    {
        EventSystem.current.SetSelectedGameObject(QuitButton);
        Cursor.visible = true; // Show the cursor
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}


