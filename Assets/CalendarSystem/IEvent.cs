using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TimeEvent
{
    public int hour;
    public int minute;
}

public abstract class IEvent : ScriptableObject
{
    [SerializeField]
    public new string name;
    [SerializeField]
    public string description;
    [SerializeField]
    public bool timedEvent = false;
    [SerializeField]
    public TimeEvent startTime;
    [SerializeField]
    public TimeEvent endTime;


    public Sprite image;

    public abstract void PlayEvent();

    public abstract void StopEvent();
}