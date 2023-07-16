using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public static Action<int> OnAddMoney;
    public static Action<int,int,int> OnCountSeeds;
    public static Action<int,int,int> OnCountFruits;
    public List<SeedSO> AllSeeds = new List<SeedSO>();
    public List<FruitSO> AllFruits = new List<FruitSO>();
    private PlayerStats playerStats;
    
    private void Start()
    {
        playerStats = PlayerStats.Instance;
    }
    private void CountAllSeeds()
    {
        int countStrawberry = AllSeeds.FindAll(obj => obj.NameId == "Strawberry").Count;   /// ВОТ ЭТО ВСЕ УЖАСНЫЙ КОСТЫЛЬ, БЫЛО БЫ БОЛЬШЕ У ПК, ТО ПРОСТО НАПИСАЛ ИНВЕНТАРЬ КАК В STARDEW
        int countMelon = AllSeeds.FindAll(obj => obj.NameId == "Melon").Count;
        int countCorn = AllSeeds.FindAll(obj => obj.NameId == "Corn").Count;

        OnCountSeeds?.Invoke(countCorn, countStrawberry, countMelon);
    }

    private void CountAllFruits()
    {
        int countStrawberry = AllFruits.FindAll(obj => obj.NameId == "Strawberry").Count;   /// ВОТ ЭТО ВСЕ УЖАСНЫЙ КОСТЫЛЬ, БЫЛО БЫ БОЛЬШЕ У ПК, ТО ПРОСТО НАПИСАЛ ИНВЕНТАРЬ КАК В STARDEW
        int countMelon = AllFruits.FindAll(obj => obj.NameId == "Melon").Count;
        int countCorn = AllFruits.FindAll(obj => obj.NameId == "Corn").Count;

        OnCountFruits?.Invoke(countCorn, countStrawberry, countMelon);
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

        CountAllFruits();
    }

    private void AddItem(SeedSO seed, int price)
    {
        if (playerStats.TotalMoney >= price)
        {
            playerStats.AddMoney(-price);
            AllSeeds.Add(seed);
        }

        CountAllSeeds();
    }
    
    public void DeleteItem(SeedSO seed)
    {
        AllSeeds.Remove(seed);

        CountAllSeeds();
    }

    public void DeleteItem(FruitSO fruit, int soldPrice)
    {
        int id = AllFruits.IndexOf(fruit);

        if (id != -1)
        {
            playerStats.AddMoney(soldPrice);
            AllFruits.Remove(fruit);
        }

        CountAllFruits();
    }
}
