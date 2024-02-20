using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInandOutController : MonoBehaviour
{
    public Image BlackScreen;
    public static bool FadeInandOut = false;
    public bool AIncreasing = false;
    public float Opacity = 0f;
    public float ChangeSpeed = 0.05f;
    private void Update()
    {
        if (FadeInandOut)
        {
            FadeInandOut = false;
            AIncreasing = true;
        }
        if (Opacity < 1f && AIncreasing)
        {
            Opacity+=ChangeSpeed;
        }
        else
        {
            if (AIncreasing)
            {
                AIncreasing = false;
            }
        }
        if (!AIncreasing && Opacity > 0f) {
            Opacity -= ChangeSpeed;      
        }
        BlackScreen.color = new Color(0f, 0f, 0f, Opacity);

    }
     
}
