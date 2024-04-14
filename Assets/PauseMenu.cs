using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public AudioSource audioSource; // Reference to the AudioSource component

    private bool isPaused = false;

    void Start()
    {
        Cursor.visible = false; // Hide the cursor initially
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor initially
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // Check for the Tab key press to toggle pause menu
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            Cursor.visible = true; // Show the cursor
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            Cursor.visible = false; // Hide the cursor
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        }
    }

    // Method to resume game (can be called by a resume button in the UI)
    public void ResumeGame()
    {
        TogglePauseMenu();
        PlayResumeSound(); // Play the audio clip after resuming the game
    }

    void PlayResumeSound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Play the audio clip
        }
    }

    // Method to open the main menu scene
    public void OpenMainMenu()
    {
        // Load the main menu scene
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("MainMenuScene");
    }


    // Method to quit the application
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
