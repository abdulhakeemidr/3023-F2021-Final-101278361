using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeatherEvent", menuName = "Date Event/Weather Event")]
public class WeatherEvent : IEvent
{
    [SerializeField]
    public GameObject weatherPrefab;

    GameObject weatherInstance;
    public override void PlayEvent()
    {
        //GameObject weather = GameObject.FindWithTag("Rain");
        //weather.SetActive(true);
        if(weatherPrefab != null)
        {
            weatherInstance = Instantiate(weatherPrefab, new Vector3(0f, 4f, -4f), Quaternion.identity);
        }

        Debug.Log("Weather");
    }

    public override void StopEvent()
    {
        if(weatherInstance != null)
        {
            Destroy(weatherInstance);
        }

        Debug.Log("Weather stop");
    }
}
