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
    public GameObject tool;
}
