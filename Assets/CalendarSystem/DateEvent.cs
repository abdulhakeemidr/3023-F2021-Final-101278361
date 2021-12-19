using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "Date Event/Event")]
public class DateEvent : IEvent
{
    public override void PlayEvent()
    {
        Debug.Log("Happy birthday");
    }

    public override void StopEvent()
    {
        Debug.Log("Event Stopped");
    }
}
