using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName ="Tool")]
public class Tool : ScriptableObject
{

    public string toolName;
    public string toolDescription;
    public int damage;
    public Sprite toolArt;
    public Sprite toolDisabledArt;
    public GameObject tool;

    public static UnityEditor.Tool None { get; set; }
    public static UnityEditor.Tool Move { get; set; }
}
