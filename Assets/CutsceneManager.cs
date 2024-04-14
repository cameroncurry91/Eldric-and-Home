using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public static bool openingCutscenePlayed;
    private PlayableDirector openingCutscene;

    void Start()
    {
        openingCutscene = GetComponent<PlayableDirector>();

        // Check if the opening cutscene has been played
        if (!openingCutscenePlayed)
        {
            // If not played, play the cutscene
            openingCutscene.Play();
            openingCutscenePlayed = true;
            GameObject floatingText = GameObject.Find("FloatingText");
            if (floatingText != null)
            {
                floatingText.SetActive(true); // Disable the text object
            }
        }
        else
        {
            // If already played, stop the cutscene
            openingCutscene.Stop();
            GameObject floatingText = GameObject.Find("FloatingText");
            if (floatingText != null)
            {
                floatingText.SetActive(false); // Disable the text object
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any additional logic here if needed
    }
}
