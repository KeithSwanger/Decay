using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    [HideInInspector]
    public Day currentDay;

    private void Awake()
    {
        StartNewDay();
    }

    public void StartNewDay()
    {
        currentDay = new Day();
    }
}
