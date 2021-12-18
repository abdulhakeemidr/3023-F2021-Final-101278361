using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DateEvent", menuName = "Events/Date Event")]
public class DateEvent : IEvent
{
    public override void PlayEvent()
    {
        Debug.Log("Happy birthday");
    }
}
