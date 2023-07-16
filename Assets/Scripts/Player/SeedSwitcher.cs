using UnityEngine;
using System;
public class SeedSwitcher : MonoBehaviour
{
    public static Action<string> OnSeedSwitch;
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
                OnSeedSwitch?.Invoke("Corn");
                break;
            case 1:
                SelectedSeed = seeds[1];
                OnSeedSwitch?.Invoke("Melon");
                break;
            case 2:
                SelectedSeed = seeds[2];
                OnSeedSwitch?.Invoke("Strawberry");
                break;
            default:
                SelectedSeed = seeds[0];
                OnSeedSwitch?.Invoke("Corn");
                break;
        }
        Debug.Log($"Selected SSED {SelectedSeed}");
    }

}
