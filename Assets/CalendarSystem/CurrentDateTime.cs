using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentDateTime : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timeTextUI;
    [SerializeField]
    TextMeshProUGUI dateTextUI;

    public static int HOUR;
    public static int MINUTE;
    public static string Day;

    int MAXHR = 24;
    int MAX_MIN = 60;
    float counter = 0;

    CalendarController calendarScript;

    private void Start()
    {
        timeTextUI = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        dateTextUI = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        calendarScript = FindObjectOfType<CalendarController>();
    }

    void Update()
    {
        Day = calendarScript.currentDate.dayTextUI.text + " day of " +
            calendarScript.seasonText.text;
        dateTextUI.text = Day;

        // TimeCounter() and DisplayCurrentTime() are based on this tutorial
        // referenced here: https://www.youtube.com/watch?v=Yn-a1Wd6baw&t=746s
        TimeCounter();
        DisplayCurrentTime();
    }

    void TimeCounter()
    {
        if (counter >= 1)
        {
            MINUTE++;
            if (MINUTE >= MAX_MIN)
            {
                MINUTE = 0;
                HOUR++;
                if (HOUR >= MAXHR)
                {
                    HOUR = 0;
                    calendarScript.SetNewDay();
                }
            }
            counter = 0;
        }
        else
        {
            counter += Time.deltaTime * calendarScript.TimeSpeed;
        }
    }

    void DisplayCurrentTime()
    {
        if(HOUR <= 9)
        {
            timeTextUI.text = "0" + HOUR + ":";
        }
        else
        {
            timeTextUI.text = HOUR + ":";
        }

        if(MINUTE <= 9)
        {
            timeTextUI.text += "0" + MINUTE;
        }
        else
        {
            timeTextUI.text += MINUTE;
        }
    }
}
