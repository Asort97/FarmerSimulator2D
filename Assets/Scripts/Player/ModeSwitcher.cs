using UnityEngine;
using System;
public class ModeSwitcher : MonoBehaviour
{
    public static Action<string> OnSwitchMode;
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
                OnSwitchMode?.Invoke("Planting");
                break;
            case 1:
                currentState = ModeStates.Collecting;
                OnSwitchMode?.Invoke("Collecting");
                break;
            case 2:
                currentState = ModeStates.Watering;
                OnSwitchMode?.Invoke("Watering");
                break;
            case 3:
                currentState = ModeStates.Destroying;
                OnSwitchMode?.Invoke("Destroying");
                break;
            default:
                currentState = ModeStates.Planting;
                OnSwitchMode?.Invoke("Planting");
                break;
        }

        Debug.Log($"State >>>" + currentState);
    }

}
