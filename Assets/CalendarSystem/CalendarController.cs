using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[System.Serializable]
public enum SeasonState
{
    WINTER,
    SPRING,
    SUMMER,
    FALL
}

public class CalendarController : MonoBehaviour
{
    [SerializeField]
    List<CalendarPanel> calendarPanels;

    [SerializeField]
    public TextMeshProUGUI seasonText;

    [SerializeField]
    WeatherEvent[] weathertype;

    [Header("Current Date/Season")]
    [SerializeField]
    public CalendarPanel currentDate;

    [SerializeField]
    public static SeasonState currentSeason;

    public float TimeSpeed = 200f;

    [Header("Day Lighting Colors")]
    [SerializeField]
    Color DayTimeLighting = new Color(1f, 0.98f, 0.76f);
    [SerializeField]
    Color DuskDawnLighting;
    [SerializeField]
    Color NightTimeLighting;
    [SerializeField]
    Light2D characterlighting;
    [SerializeField]
    Light2D GlobalLighting;

    void Start()
    {
        GetCalendarPanels();
        currentSeason = SeasonState.SUMMER;
        seasonText = GameObject.FindWithTag("Season Text").GetComponent<TextMeshProUGUI>();
        // sets calendar date to the first date
        currentDate = calendarPanels[0];
        currentDate.PlayWeatherEvent();
        DisplayCurrentState();
    }

    void GetCalendarPanels()
    {
        calendarPanels = new List<CalendarPanel>();
        var datePanels = GetComponentsInChildren<CalendarPanel>();
        for (int i = 0; i < datePanels.Length; i++)
        {
            // Sets the day number of the panel
            datePanels[i].dayTextUI.text = (i + 1).ToString();
            calendarPanels.Add(datePanels[i]);
            calendarPanels[i].weatherEvent = weathertype[0];
        }
    }

    void DisplayCurrentState()
    {
        switch (currentSeason)
        {
            case SeasonState.WINTER:
                seasonText.text = "WINTER";
                break;
            case SeasonState.SPRING:
                seasonText.text = "SPRING";
                break;
            case SeasonState.SUMMER:
                seasonText.text = "SUMMER";
                break;
            case SeasonState.FALL:
                seasonText.text = "FALL";
                break;
            default:
                break;
        }
    }

    void changeSeasonState()
    {
        if (currentSeason == SeasonState.FALL)
        {
            currentSeason = SeasonState.WINTER;
        }
        else
        {
            currentSeason++;
        }
        DisplayCurrentState();
    }

    public void SetNewDay()
    {
        for(int i = 0; i < calendarPanels.Count; i++)
        {
            if(currentDate != null && currentDate == calendarPanels[i])
            {
                currentDate.StopWeatherEvent();
                if(i < calendarPanels.Count - 1)
                {
                    // sets to the first day of new season
                    currentDate = calendarPanels[i + 1];
                }
                else if (i >= calendarPanels.Count - 1)
                {
                    // resets to the first day of new season
                    currentDate = calendarPanels[0];
                    changeSeasonState();
                }
                currentDate.PlayWeatherEvent();
                break;
            }
        }
    }
}
