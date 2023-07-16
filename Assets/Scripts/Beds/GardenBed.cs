using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GardenBed : MonoBehaviour
{
    public static Action<FruitSO> OnCollectFruits;
    [SerializeField] private SeedSO currentSeed;
    [SerializeField] private SpriteRenderer seedSprite;
    [SerializeField] private SpriteRenderer bedSprite;
    private bool isWatered = false;
    private bool isCollectable;
    private int daysWithoutWatering = 0;
    private int dayAfterPlanting = 0;
    private float Durability = 4f;
    public bool IsPlanted;

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

            bedSprite.color = new Color(255,255,255);

            foreach (var state in currentSeed.StatesSeedSprites)
            {
                if (dayAfterPlanting == state.stateDay)
                {
                    seedSprite.sprite = state.stateSprite;
                }
            }       

            if (dayAfterPlanting == currentSeed.AverageDaysToGrow)
            {
                isCollectable = true;
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
            IsPlanted = true;

            Debug.Log($"{this.name} was planting with {seed}");

            seedSprite.sprite = currentSeed.StatesSeedSprites[0].stateSprite;            
        }
    }

    public void WateringSeed() // Полить
    {
        isWatered = true;
        bedSprite.color = Color.gray;
    }
    public void DestroySeed() // Превратить в мусор
    {
        dayAfterPlanting = 0;
        daysWithoutWatering = 0;        

        isWatered = false;
        isCollectable = false;
        IsPlanted = false;
        currentSeed = null;
        seedSprite.sprite = null;
    }
    public void CollectFruits() // Собрать все
    {
        if (isCollectable)
        {
            OnCollectFruits?.Invoke(currentSeed.ResultFruit);
            DestroySeed();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Durability -= Time.deltaTime;
            if(Durability <= 0f)
            {
                DestroySeed();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Durability = 5f;
        }
    }
}
