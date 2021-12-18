using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalendarPanel : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI dayText;
    void Start()
    {
        dayText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
