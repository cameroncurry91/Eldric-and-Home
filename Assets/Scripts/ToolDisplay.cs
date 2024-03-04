using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolDisplay : MonoBehaviour
{
    public Tool tool;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI displayDescription;
    public TextMeshProUGUI displayDamage;
    public Image displayImage;

    // Start is called before the first frame update
    void Start()
    {
        if(displayName != null && tool != null)
            displayName.text = tool.toolName;
        if(displayDescription != null && tool != null)
            displayDescription.text = tool.toolDescription;
        if(displayDamage != null && tool != null)
            displayDamage.text = tool.damage.ToString();
        if(displayImage != null && tool != null)
            displayImage.sprite = tool.toolArt;

    }

    // Update is called once per frame
    void Update()
    {
        if (displayName != null && tool != null && displayName.text != tool.toolName)
            displayName.text = tool.toolName;
        if (displayDescription != null && tool != null && displayDescription.text != tool.toolDescription)
            displayDescription.text = tool.toolDescription;
        if (displayDamage != null && tool != null && displayDamage.text != tool.damage.ToString())
            displayDamage.text = tool.damage.ToString();
        if (displayImage != null && tool != null && displayImage.sprite != tool.toolArt)
            displayImage.sprite = tool.toolArt;
    }
}
