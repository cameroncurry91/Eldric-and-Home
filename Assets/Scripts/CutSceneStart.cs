using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SignalReciever))]
public  class CutSceneStart : Interactable
{

    [SerializeField] private GameObject _CutSceneToPlay;
    public override void Activate()
    {
        base.Activate();    
    
    }

    public override void Deactivate()
    {
        base.Deactivate();

    }

}

internal class SignalReciever
{
}