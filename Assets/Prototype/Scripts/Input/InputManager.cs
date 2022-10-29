using System;
using UnityEngine;

public  class InputManager
{
    public event Action OnMouseDown = delegate { };
    public event Action OnMouseUp = delegate { };

    public Vector2 MousePosition => input.Land.MousePos.ReadValue<Vector2>();
    private InputActions input;

    public InputManager()
    {
        input = new InputActions();
        input.Enable();
        
        SetupEvents();
    }

    private void SetupEvents()
    {
        input.Land.Click.started += (_) => OnStart();
        input.Land.Click.canceled += (_) => OnCancel();
    }

    private void OnStart()
    {
        OnMouseDown();
    }
    
    private void OnCancel()
    {
        OnMouseUp();
    }
}
