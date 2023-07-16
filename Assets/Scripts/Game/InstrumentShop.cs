using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InstrumentShop : MonoBehaviour
{
    public static Action OnUpgradeInstruments;
    [SerializeField] private int priceUpgradeLevel;
    private Button newLevelButton;
    private PlayerStats playerStats;
    private void Start()
    {
        playerStats = PlayerStats.Instance;
        newLevelButton = GetComponent<Button>();    

        newLevelButton.onClick.AddListener(UpgradeLVL);
    }
    private void UpgradeLVL()
    {
        if (playerStats.TotalMoney >= priceUpgradeLevel && playerStats.InstrumentLevel < 3)
        {
            OnUpgradeInstruments?.Invoke();

            playerStats.AddMoney(-priceUpgradeLevel);
        }
    }
}
