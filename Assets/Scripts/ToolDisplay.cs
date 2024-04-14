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
    public Sprite disabledImage;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        if(displayName != null && tool != null)
            displayName.text = tool.toolName;
        if(displayDescription != null && tool != null)
            displayDescription.text = tool.toolDescription;
        if(displayDamage != null && tool != null)
            displayDamage.text = tool.damage.ToString();
        if(displayImage != null && tool != null)
            displayImage.sprite = tool.toolArt;
        else if(displayImage != null && tool == null && disabledImage != null)
        {
            button.interactable = false;
            displayImage.sprite = disabledImage;
        }
            

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
        {
            button.interactable = true;
            displayImage.sprite = tool.toolArt;
        }
        else if (displayImage != null && tool == null && disabledImage != null && displayImage.sprite != disabledImage)
        {
            displayImage.sprite = disabledImage;
            button.interactable = false;
        }
            
    }
}
