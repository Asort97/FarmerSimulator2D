using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SeedSO> AllSeeds = new List<SeedSO>();
    public List<FruitSO> AllFruits = new List<FruitSO>();
    private void OnEnable()
    {
        SeedShopButton.OnBuyingSeed += AddItem; 
        GardenBed.OnCollectFruits += AddItem;
    }
    private void OnDisable()
    {
        SeedShopButton.OnBuyingSeed -= AddItem; 
        GardenBed.OnCollectFruits -= AddItem;
    }

    public void AddItem(FruitSO fruit)
    {
        AllFruits.Add(fruit);
    }
    public void AddItem(SeedSO seed)
    {
        AllSeeds.Add(seed);
    }
    
    public void DeleteItem(SeedSO seed)
    {
        AllSeeds.Remove(seed);
    }
    public void DeleteItem(FruitSO fruit)
    {
        AllFruits.Remove(fruit);
    }
}
