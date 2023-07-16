using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SeedSO> AllSeeds = new List<SeedSO>();
    public List<FruitSO> AllFruits = new List<FruitSO>();
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = PlayerStats.Instance;
    }

    private void OnEnable()
    {
        SeedShopButton.OnBuyingSeed += AddItem;
        SoldShopButton.OnSoldFruit += DeleteItem; 
        GardenBed.OnCollectFruits += AddItem;
    }

    private void OnDisable()
    {
        SoldShopButton.OnSoldFruit -= DeleteItem; 
        SeedShopButton.OnBuyingSeed -= AddItem; 
        GardenBed.OnCollectFruits -= AddItem;
    }

    private void AddItem(FruitSO fruit)
    {
        AllFruits.Add(fruit);
    }

    private void AddItem(SeedSO seed, int price)
    {
        if (playerStats.TotalMoney >= price)
        {
            playerStats.TotalMoney -= price;
            AllSeeds.Add(seed);
        }
    }
    
    public void DeleteItem(SeedSO seed)
    {
        AllSeeds.Remove(seed);
    }

    public void DeleteItem(FruitSO fruit, int soldPrice)
    {
        int id = AllFruits.IndexOf(fruit);

        if (id != -1)
        {
            playerStats.TotalMoney += soldPrice;
            AllFruits.Remove(fruit);
        }
    }
}
