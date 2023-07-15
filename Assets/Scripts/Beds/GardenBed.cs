using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenBed : MonoBehaviour
{
    [SerializeField] private SpriteRenderer seedSprite;
    [SerializeField] private SeedSO currentSeed;
    private bool isWatered = false;
    private bool isCollectable;
    private int daysWithoutWatering = 0;
    private int dayAfterPlanting = 0;

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
        if(currentSeed != null)
        {
            dayAfterPlanting++;

            foreach (var state in currentSeed.StatesSeedSprites)
            {
                if (dayAfterPlanting == state.stateDay)
                {
                    seedSprite.sprite = state.stateSprite;
                }
            }       

            if(!isWatered)
            {
                daysWithoutWatering++;

                if(daysWithoutWatering == 3)
                {
                    DestroySeed();
                }
            }
            else
            {
                daysWithoutWatering = 0;
            }
            isWatered = false;
        }
    }

    public void PlantingSeed(SeedSO seed) // Посадить
    {
        if (!currentSeed)
        {
            currentSeed = seed;
            Debug.Log($"{this.name} was planting with {seed}");

            seedSprite.sprite = currentSeed.StatesSeedSprites[0].stateSprite;            
        }
    }

    public void WateringSeed() // Полить
    {
        isWatered = true;
    }
    public void DestroySeed() // Превратить в мусор
    {
        currentSeed = null;
        seedSprite.sprite = null;
    }
    public void CollectFruits() // Собрать все
    {
    }
}
