
using System;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    public delegate void StartTouchInput(Vector2 position, float time);
    public event StartTouchInput OnStartTouch;
    public delegate void EndTouchInput(Vector2 position, float time);
    public event EndTouchInput OnEndTouch;
    public delegate void StartPressTouch();
    public event StartPressTouch OnTouchPress;
    public delegate void EndPressTouch();
    public event StartPressTouch OnTouchRelease;

    private PlayerControls playerControls;
    private Camera mainCamera;
    private void Awake()
    {
        playerControls = new PlayerControls();
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    void Start()
    {
        playerControls.Touch.Contact.started += context => StartTouch(context);
        playerControls.Touch.Contact.canceled += context => EndTouch(context);

        playerControls.Touch.Touch.started += context => TouchPressStarted(context);
        playerControls.Touch.Touch.canceled += context => TouchPressReleased(context);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) OnEndTouch(Utils.ScreenToWorldPosition(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        if(OnStartTouch != null) OnStartTouch(Utils.ScreenToWorldPosition(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }


    private void TouchPressStarted(InputAction.CallbackContext context)
    {
        if (OnTouchPress != null) OnTouchPress();
    }

    private void TouchPressReleased(InputAction.CallbackContext context)
    {

    }
}
