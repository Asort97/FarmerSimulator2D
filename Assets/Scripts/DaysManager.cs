using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DaysManager : MonoBehaviour
{
    public static Action OnSkipDay;
    private int currentDay = 1;
    public void SkipDay()
    {
        currentDay++;
        OnSkipDay.Invoke();
    }
}
