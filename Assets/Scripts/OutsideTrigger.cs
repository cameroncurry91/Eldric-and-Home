using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OutsideTrigger : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Vector3 playerSpawnPosition; // Position where you want to spawn the player
    public TextMeshProUGUI ProgressText; // Change type to TextMeshProUGUI


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(LoadSceneAsyncWithProgress());
    }

    IEnumerator LoadSceneAsyncWithProgress()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        operation.allowSceneActivation = false; // Prevent automatic scene activation

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Progress until 90%
            progress += (operation.progress >= 0.9f) ? 0 : 0; // Add 1 when operation.progress reaches 0.9
            slider.value = progress;
            ProgressText.text = progress * 100f + "%";

            // If the load is almost complete, allow the scene to activate
            if (operation.progress >= 0.9f && progress >= 1f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       
         Debug.Log("Scene loaded: " + scene.name);

        // Check if the loaded scene is the one you want to spawn the player in
        if (scene.buildIndex == 1)
        {
            // Find the player GameObject (assuming it's tagged as "Player")
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // Set the player's position to the specified spawn position
                player.transform.position = playerSpawnPosition;
            }
            else
            {
                Debug.LogError("Player GameObject not found!");
            }

            // Reset slider value for future use
            slider.value = 0f;
        }
    }
}
