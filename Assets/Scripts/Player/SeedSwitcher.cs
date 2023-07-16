using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SeedSwitcher : MonoBehaviour
{
    [HideInInspector] public SeedSO SelectedSeed;
    [SerializeField] private SeedSO[] seeds;
    private int idSeed;

    public void SwitchSeed()
    {
        idSeed++;
        
        if (idSeed == seeds.Length)
        {
            idSeed = 0;
        }       
        
        switch (idSeed)
        {
            case 0:
                SelectedSeed = seeds[0];
                break;
            case 1:
                SelectedSeed = seeds[1];
                break;
            case 2:
                SelectedSeed = seeds[2];
                break;
            default:
                SelectedSeed = seeds[0];
                break;
        }
        Debug.Log($"Selected SSED {SelectedSeed}");
    }

}
