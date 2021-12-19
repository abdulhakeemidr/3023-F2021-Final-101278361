using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalendarPanel : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI dayTextUI;

    [SerializeField]
    public WeatherEvent weatherEvent;

    [SerializeField]
    List<IEvent> scriptableEvents;

    Button datePanelButton;

    GameObject dayDetailsPanel;

    CalendarController controller;

    Color originalColor;

    private void Awake()
    {

        dayDetailsPanel = GameObject.Find("Day Details");
    }

    void Start()
    {
        dayTextUI = GetComponentInChildren<TextMeshProUGUI>();
        controller = GetComponentInParent<CalendarController>();
        originalColor = this.gameObject.GetComponent<Image>().color;
        datePanelButton = GetComponent<Button>();
        //datePanelButton.onClick.AddListener(delegate { dayDetailsPanel.SetActive(true); });
        datePanelButton.onClick.AddListener(ToggleDayDetailsPanel);
    }

    void Update()
    {
        // increases the brightness of the current date on the calendar
        if(controller.currentDate == this)
        {
            this.gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
        else if (controller.currentDate != this)
        {
            this.gameObject.GetComponent<Image>().color = originalColor;
        }
    }

    public void PlayAllEvents()
    {
        foreach (IEvent happened in scriptableEvents)
        {
            happened.PlayEvent();
            Debug.Log(dayTextUI.text);
        }
    }

    public void StopAllEvents()
    {
        foreach (IEvent happened in scriptableEvents)
        {
            happened.StopEvent();
            Debug.Log(dayTextUI.text);
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

    void ToggleDayDetailsPanel()
    {
        dayDetailsPanel.SetActive(true);
        var textUI = DayDetails.selectedDayText.GetComponent<TextMeshProUGUI>();
        textUI.text = dayTextUI.text + " day of " +
            CalendarController.currentSeason;
    }
}
