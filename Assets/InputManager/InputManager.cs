using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance {
        get {
            return instance;
        }
    }
    private PlayerControls playerControls;

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
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    public Vector2 GetPlayerPosition()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }
    public bool GetUseTrigger()
    {
        return playerControls.Player.Action.triggered;
    }

    public bool GetSwitchModeTrigger()
    {
        return playerControls.Player.SwitchMode.triggered;
    }

    public bool GetSwitchGrainsTriggger()
    {
        return playerControls.Player.SwitchGrains.triggered;
    }
    public bool GetSkipDayTrigger()
    {
        return playerControls.Player.SkipDay.triggered;
    }
}
