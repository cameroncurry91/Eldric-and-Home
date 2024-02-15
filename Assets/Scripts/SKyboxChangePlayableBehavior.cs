using UnityEngine;
using UnityEngine.Playables;

public class SkyboxChangePlayableBehaviour : PlayableBehaviour
{
    public string CloudedSunGlow;
   

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        base.OnBehaviourPlay(playable, info);

        SkyboxChanger skyboxChanger = GameObject.FindObjectOfType<SkyboxChanger>();
        if (skyboxChanger != null)
        {
            skyboxChanger.ChangeSkybox(CloudedSunGlow);
        }
        else
        {
            Debug.LogWarning("SkyboxChanger not found in the scene.");
        }
    }
}
