using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalendarPanel : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI dayText;

    [SerializeField]
    public WeatherEvent weatherEvent;

    [SerializeField]
    List<IEvent> events;

    CalendarController controller;

    Color originalColor;

    void Start()
    {
        dayText = GetComponentInChildren<TextMeshProUGUI>();
        controller = GetComponentInParent<CalendarController>();
        originalColor = this.gameObject.GetComponent<UnityEngine.UI.Image>().color;
    }

    void Update()
    {
        // increases the brightness of the current date on the calendar
        if(controller.currentDate == this)
        {
            this.gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f);
        }
        else if (controller.currentDate != this)
        {
            this.gameObject.GetComponent<UnityEngine.UI.Image>().color = originalColor;
        }
    }

    public void PlayAllEvents()
    {
        foreach (IEvent happened in events)
        {
            happened.PlayEvent();
            Debug.Log(dayText.text);
        }
    }

    public void StopAllEvents()
    {
        foreach (IEvent happened in events)
        {
            happened.StopEvent();
            Debug.Log(dayText.text);
        }
    }

    public void PlayWeatherEvent()
    {
        weatherEvent.PlayEvent();
    }

    public void StopWeatherEvent()
    {
        weatherEvent.StopEvent();
    }
}
