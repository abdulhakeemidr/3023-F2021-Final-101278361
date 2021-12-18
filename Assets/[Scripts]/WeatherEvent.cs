using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DateEvent", menuName = "Events/Weather Event")]
public class WeatherEvent : IEvent
{
    [SerializeField]
    GameObject weather;

    public override void PlayEvent()
    {
    }
}
