using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class SeedShopButton : MonoBehaviour
{
    [SerializeField] private SeedSO seed;
    [SerializeField] private int price;
    private Button buyButton;
    public static Action<SeedSO> OnBuyingSeed;
    private PlayerStats playerStats;
    private void Start()
    {
        playerStats = PlayerStats.Instance;
        buyButton = GetComponent<Button>();
        buyButton.onClick.AddListener(BuySeed);
    }
    public void BuySeed()
    {
        if (playerStats.TotalMoney >= price)
        {
            OnBuyingSeed?.Invoke(seed);
            playerStats.TotalMoney -= price;            
        }
    }
}
