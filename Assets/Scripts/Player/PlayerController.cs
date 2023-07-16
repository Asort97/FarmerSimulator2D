using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public static Action<int> OnCompletedAction;
    [SerializeField] private float speedMove;
    private PlayerStats playerStats;
    private CellSelector cellSelector;
    private DaysManager daysManager;
    private Inventory inventory;
    private Rigidbody2D rb;
    private ModeSwitcher modeSwitcher;
    private SeedSwitcher seedSwitcher;
    private InputManager inputManager;
    private float timeToPlant;
    private float timeToWater;
    private float timeToDestroy;
    private float timeToCollect;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();

        inventory = FindObjectOfType<Inventory>();
        cellSelector = GetComponent<CellSelector>();
        modeSwitcher = GetComponent<ModeSwitcher>();
        seedSwitcher = GetComponent<SeedSwitcher>();

        daysManager = FindObjectOfType<DaysManager>();

        inputManager = InputManager.Instance;
        playerStats = PlayerStats.Instance;

        SetPlayerStats();
    }
    private void SetPlayerStats()
    {
        timeToCollect = playerStats.TimeToCollect;
        timeToPlant  = playerStats.TimeToPlant;
        timeToDestroy = playerStats.TimeToDestroy;
        timeToWater = playerStats.TimeToWater;
    }
    private void Update()
    {
        Movement();
        SwitchMode();
        SwitchSeeds();
        SkipDay();
        OnAction();
    }
    private void Movement()
    {
        Vector2 move = new Vector2(inputManager.GetPlayerPosition().x, inputManager.GetPlayerPosition().y);
        if(move.x != 0f || move.y != 0f)
        {
            transform.Translate(move * speedMove * Time.deltaTime); 

            Vector2 lookDirection = new Vector2(move.x, move.y);
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;     
        }
    }
    private void OnAction() 
    {
        if(inputManager.GetUseTrigger() && cellSelector.SelectorRaduis().Length != 0)
        {
            switch (modeSwitcher.currentState)
            {
                case ModeSwitcher.ModeStates.Planting:
                    StartPlanting();
                    break;
                case ModeSwitcher.ModeStates.Collecting:
                    StartCollecting();
                    break;
                case ModeSwitcher.ModeStates.Destroying:
                    StartDestroying();
                    break;
                case ModeSwitcher.ModeStates.Watering:
                    StartWatering();
                    break;
            }
        }
    }
    private void StartPlanting()
    {
        int id = inventory.AllSeeds.IndexOf(seedSwitcher.SelectedSeed);

        if (id != -1)
        {
            if (timeToPlant <= 0f)
            {
                cellSelector.SelectorClosestBed(modeSwitcher.currentState).GetComponent<GardenBed>().PlantingSeed(seedSwitcher.SelectedSeed);
                inventory.DeleteItem(seedSwitcher.SelectedSeed);
                
                OnCompletedAction?.Invoke(10);
                
                timeToPlant = playerStats.TimeToPlant;
            }
            else
            {
                timeToPlant -= Time.deltaTime;
            }            
        }
    }
    private void StartDestroying()
    {
        if (timeToDestroy <= 0f)
        {
            cellSelector.SelectorClosestBed(modeSwitcher.currentState).GetComponent<GardenBed>().DestroySeed();

            timeToDestroy = playerStats.TimeToDestroy;

            OnCompletedAction?.Invoke(2);
        }
        else
        {
            timeToDestroy -= Time.deltaTime;
        }
    }
    private void StartCollecting()
    {
        if (timeToCollect <= 0f)
        {
            foreach (var bed in cellSelector.SelectorRaduis())
            {
                bed.GetComponent<GardenBed>().CollectFruits();

                timeToCollect = playerStats.TimeToCollect;

                OnCompletedAction?.Invoke(20);
            }
        }
        else
        {
            timeToCollect -= Time.deltaTime;
        }
    }
    private void StartWatering()
    {
        if (timeToWater <= 0f)
        {
            foreach (var bed in cellSelector.SelectorRaduis())
            {
                bed.GetComponent<GardenBed>().WateringSeed();
                timeToWater = playerStats.TimeToWater;

                OnCompletedAction?.Invoke(5);
            }
        }
        else
        {
            timeToWater -= Time.deltaTime;
        }
    }

    private void SwitchMode()
    {
        if (inputManager.GetSwitchModeTrigger()) 
        {
            modeSwitcher.SwitchMode();
        }
    }

    private void SwitchSeeds()
    {
        if(inputManager.GetSwitchSeedsTrigger())
        {
            seedSwitcher.SwitchSeed();
        }
    }

    private void SkipDay()
    {
        if (inputManager.GetSkipDayTrigger())
        {
            daysManager.SkipDay();
        }
    }

}
