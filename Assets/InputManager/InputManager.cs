using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance {
        get {
            return instance;
        }
    }
    private PlayerControls playerControls;
    private bool actionButtonIsHold;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        playerControls = new PlayerControls();
    }
    
    private void OnEnable()
    {
        playerControls.Enable();

        playerControls.Player.Action.started += OnStartHoldActionButton;
        playerControls.Player.Action.canceled += OnEndHoldActionButton;
    }
    private void OnDisable()
    {
        playerControls.Disable();

        playerControls.Player.Action.started -= OnStartHoldActionButton;
        playerControls.Player.Action.canceled -= OnEndHoldActionButton;
    }
    private void OnStartHoldActionButton(InputAction.CallbackContext callbackContext)
    {
        actionButtonIsHold = true;
    }
    private void OnEndHoldActionButton(InputAction.CallbackContext callbackContext)
    {
        actionButtonIsHold = false;
    }
    public Vector2 GetPlayerPosition()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }
    public bool GetUseTrigger()
    {
        return actionButtonIsHold;
    }

    public bool GetSwitchModeTrigger()
    {
        return playerControls.Player.SwitchMode.triggered;
    }

    public bool GetSwitchSeedsTrigger()
    {
        return playerControls.Player.SwitchSeeds.triggered;
    }
    public bool GetSkipDayTrigger()
    {
        return playerControls.Player.SkipDay.triggered;
    }
}
