using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayDetails : MonoBehaviour
{
    public static GameObject selectedDay;
    public static GameObject selectedDayText;
    public static GameObject DetailsText;

    void Start()
    {
        selectedDay = gameObject.transform.GetChild(0).gameObject;
        selectedDayText = gameObject.transform.GetChild(1).gameObject;
        DetailsText = gameObject.transform.GetChild(2).gameObject;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
