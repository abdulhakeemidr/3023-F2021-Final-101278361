using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum SeasonState
{
    WINTER,
    SPRING,
    SUMMER,
    FALL
}

public class CalendarController : MonoBehaviour
{
    [SerializeField]
    List<CalendarPanel> calendarDates;

    [SerializeField]
    TextMeshProUGUI seasonText;

    [SerializeField]
    SeasonState currentSeason;

    [SerializeField]
    CalendarPanel currentDate;

    void Start()
    {
        GetCalendarPanels();
        currentSeason = SeasonState.SUMMER;
        seasonText = GameObject.FindWithTag("Season Text").GetComponent<TextMeshProUGUI>();

        currentDate = calendarDates[0];
    }

    void GetCalendarPanels()
    {
        calendarDates = new List<CalendarPanel>();
        var datePanels = GetComponentsInChildren<CalendarPanel>();
        for (int i = 0; i < datePanels.Length; i++)
        {
            // Sets the day number of the panel
            datePanels[i].dayText.text = (i + 1).ToString();
            calendarDates.Add(datePanels[i]);
        }
    }

    void Update()
    {
        onCurrentState();

        currentDate.PlayEvent();
    }

    void onCurrentState()
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
}
