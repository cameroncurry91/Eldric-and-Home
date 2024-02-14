using UnityEngine;
using UnityEngine.Rendering;

public class SkyboxChanger : MonoBehaviour
{
    public void ChangeSkybox(string CloudedSunGlow)
    {
        // Find the skybox material by name
        Material skyboxMaterial = Resources.Load<Material>(CloudedSunGlow);
        if (skyboxMaterial != null)
        {
            // Change the skybox material
            RenderSettings.skybox = skyboxMaterial;
        }
        else
        {
            Debug.LogWarning("Skybox material not found: " + CloudedSunGlow);
        }
    }
}

