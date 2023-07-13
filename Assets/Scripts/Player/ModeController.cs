using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    [SerializeField] private ModeStates currentState;
    private int idMode;
    private enum ModeStates
    {
        Planting,
        Watering,
        Collecting,
        Destroying
    }
    public void SwitchMode()
    {
        idMode++;

        if (idMode == 4)
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
 
    }

}
