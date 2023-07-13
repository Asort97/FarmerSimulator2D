using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenBed : MonoBehaviour
{
    [SerializeField] private SpriteRenderer seedSprite;
    private SeedSO currentSeed;
    private int dayAfterPlanting;

    private void OnEnable()
    {
        DaysManager.OnSkipDay += OnNextDay;
    }
    private void OnDisable()
    {
        DaysManager.OnSkipDay -= OnNextDay;
    }
    private void OnNextDay()
    {
        dayAfterPlanting++;
    }
    public void PlantSeed(SeedSO seed)
    {
        currentSeed = seed;
    }
}
