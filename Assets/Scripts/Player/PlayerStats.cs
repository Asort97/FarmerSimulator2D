using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public static Action<int> OnNewLevel;
    public static Action<int> OnNewInstrumentLevel;
    public static Action<int> OnMoneyUpdate;

    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get {
            return instance;
        }
    }
    private float experienceBar;
    public float ActionRaduis;
    public int TotalMoney;
    public int Level = 1;
    public int InstrumentLevel = 1;
    public float Stamina = 100f;
    public float TimeToPlant;
    public float TimeToCollect;
    public float TimeToDestroy;
    public float TimeToWater;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        PlayerController.OnCompletedAction += AddExperience;
        DaysManager.OnSkipDay += RefreshPlayerStats;
        InstrumentShop.OnUpgradeInstruments += UpgradeInstruments;
    }

    private void OnDisable()
    {
        PlayerController.OnCompletedAction -= AddExperience;
        DaysManager.OnSkipDay -= RefreshPlayerStats;
        InstrumentShop.OnUpgradeInstruments -= UpgradeInstruments;
    }

    private void RefreshPlayerStats(int day)
    {
        Stamina = 100f;
    }

    private void AddExperience(int exp)
    {
        Stamina = Mathf.Clamp(Stamina - 5f, 0f, 100f);
        
        experienceBar += exp;

        if (experienceBar % 40 == 0)
        {
            UpdateLevel();
        }
    }

    private void UpdateLevel()
    {
        Level++;

        OnNewLevel?.Invoke(Level);

        TimeToCollect -= 0.1f;
        TimeToDestroy -= 0.1f;
        TimeToPlant -= 0.1f;
        TimeToWater -= 0.1f;
    }

    private void UpgradeInstruments()
    {
        InstrumentLevel++;
        ActionRaduis += 0.15f;

        OnNewInstrumentLevel?.Invoke(InstrumentLevel);
    }

    public void AddMoney(int money)
    {
        TotalMoney += money;

        OnMoneyUpdate?.Invoke(TotalMoney);
    }

}
