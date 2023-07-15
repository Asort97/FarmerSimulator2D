using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private SeedSO testSeed;
    private PlayerStats playerStats;
    private CellSelector cellSelector;
    private DaysManager daysManager;
    private Rigidbody2D rb;
    private ModeController modeController;
    private InputManager inputManager;
    private float timeToPlant;
    private float timeToWater;
    private float timeToDestroy;
    private float timeToCollect;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();

        playerStats = GetComponent<PlayerStats>();
        cellSelector = GetComponent<CellSelector>();
        modeController = GetComponent<ModeController>();

        daysManager = FindObjectOfType<DaysManager>();

        inputManager = InputManager.Instance;

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
            switch (modeController.currentState)
            {
                case ModeController.ModeStates.Planting:
                    SetPlanting();
                    break;
                case ModeController.ModeStates.Collecting:
                    SetCollecting();
                    break;
                case ModeController.ModeStates.Destroying:
                    SetDestroying();
                    break;
                case ModeController.ModeStates.Watering:
                    SetWatering();
                    break;
            }
        }
    }
    private void SetPlanting()
    {
        if (timeToPlant <= 0f)
        {
            foreach (var bed in cellSelector.SelectorRaduis())
            {
                bed.GetComponent<GardenBed>().PlantingSeed(testSeed);
                timeToPlant = playerStats.TimeToPlant;
            }
        }
        else
        {
            timeToPlant -= Time.deltaTime;
        }
    }
    private void SetDestroying()
    {
        if (timeToDestroy <= 0f)
        {
            foreach (var bed in cellSelector.SelectorRaduis())
            {
                bed.GetComponent<GardenBed>().DestroySeed();
                timeToDestroy = playerStats.TimeToDestroy;
            }
        }
        else
        {
            timeToDestroy -= Time.deltaTime;
        }
    }
    private void SetCollecting()
    {
        if (timeToCollect <= 0f)
        {
            foreach (var bed in cellSelector.SelectorRaduis())
            {
                bed.GetComponent<GardenBed>().CollectFruits();
                timeToCollect = playerStats.TimeToCollect;
            }
        }
        else
        {
            timeToCollect -= Time.deltaTime;
        }
    }
    private void SetWatering()
    {
        if (timeToWater <= 0f)
        {
            foreach (var bed in cellSelector.SelectorRaduis())
            {
                bed.GetComponent<GardenBed>().WateringSeed();
                timeToWater = playerStats.TimeToWater;
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
            modeController.SwitchMode();
        }
    }
    private void SwitchSeeds()
    {
        if(inputManager.GetSwitchSeedsTrigger())
        {

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
