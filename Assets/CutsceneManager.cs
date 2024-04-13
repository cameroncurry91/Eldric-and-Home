using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{

    public static bool openingCutscenePlayed;
    private PlayableDirector openingcutscene;
   
    // Start is called before the first frame update
    void Start()
    {
        openingcutscene = GetComponent<PlayableDirector>();
        if (openingCutscenePlayed == false)
        {
            openingcutscene.Play();
            openingCutscenePlayed = true;
        }
        else
        {
            openingcutscene.Stop();
            openingCutscenePlayed = false;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
