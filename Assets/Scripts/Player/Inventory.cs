using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SeedSO> AllSeeds = new List<SeedSO>();
    public void AddSeed(SeedSO seed)
    {
        AllSeeds.Add(seed);
    }
    
    public void DeleteSeed(SeedSO seed)
    {
        AllSeeds.Remove(seed);
    }
}
