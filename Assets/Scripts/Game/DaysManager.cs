using UnityEngine;
using System;
public class DaysManager : MonoBehaviour
{
    public static Action<int> OnSkipDay;
    private int currentDay = 1;
    
    public void SkipDay()
    {
        Debug.Log($"Skip day {currentDay}");
        
        currentDay++;

        OnSkipDay.Invoke(currentDay);
    }
}
