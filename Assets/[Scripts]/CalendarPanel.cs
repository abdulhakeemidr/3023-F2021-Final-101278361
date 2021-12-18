using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalendarPanel : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI dayText;

    [SerializeField]
    List<IEvent> events;

    void Start()
    {
        dayText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    public void PlayEvent()
    {
        foreach (IEvent happened in events)
        {
            happened.PlayEvent();
            Debug.Log(dayText.text);
        }
    }
}
