using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedMove;
    private DaysManager daysManager;
    private Rigidbody2D rb;
    private ModeController modeController;
    private InputManager inputManager;
    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        modeController = GetComponent<ModeController>();
        daysManager = FindObjectOfType<DaysManager>();
        inputManager = InputManager.Instance;
    }
    private void Update()
    {
        Movement();
        SwitchMode();
        SkipDay();
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
    private void SwitchMode()
    {
        if (inputManager.GetSwitchModeTrigger()) 
        {
            modeController.SwitchMode();
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
