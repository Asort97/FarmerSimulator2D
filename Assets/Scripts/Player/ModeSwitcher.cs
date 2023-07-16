using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ModeSwitcher : MonoBehaviour
{
    [HideInInspector] public ModeStates currentState;
    private int idMode;
    public enum ModeStates
    {
        Planting,
        Watering,
        Collecting,
        Destroying
    }
    public void SwitchMode()
    {
        idMode++;

        if (idMode == Enum.GetNames(typeof(ModeStates)).Length)
        {
            idMode = 0;
        }       
        
        switch (idMode)
        {
            case 0:
                currentState = ModeStates.Planting;
                break;
            case 1:
                currentState = ModeStates.Collecting;
                break;
            case 2:
                currentState = ModeStates.Watering;
                break;
            case 3:
                currentState = ModeStates.Destroying;
                break;
            default:
                currentState = ModeStates.Planting;
                break;
        }

        Debug.Log($"State >>>" + currentState);
    }

}
