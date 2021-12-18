using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEvent : ScriptableObject
{
    [SerializeField]
    public new string name;
    [SerializeField]
    public string description;

    public Sprite image;

    public abstract void PlayEvent();
}