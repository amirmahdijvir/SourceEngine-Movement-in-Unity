using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
  

    InputSystem_Actions inputSystem;
    public MovementConfig movementConfig = new MovementConfig();
    public event Action<bool> OnJumpPressed;
    public bool bunnyHop;
    
    private void Awake()
    {
        inputSystem = new InputSystem_Actions();
        inputSystem.Player.Move.performed += (ctx) =>
        {
            movementConfig.wishDirection = ctx.ReadValue<Vector2>();
        };
        inputSystem.Player.Look.performed += ( ctx) =>
        {
            movementConfig.lookDirection = ctx.ReadValue<Vector2>();
            
        };
        // Check if bunnyHop is enabled, if so, use performed event, otherwise use started event
        if (bunnyHop)
        {
            inputSystem.Player.Jump.performed += (ctx) =>
            {
                OnJumpPressed?.Invoke(true);
                Debug.Log("Jump Pressed");
            };
        }
        else
        {
            inputSystem.Player.Jump.started += (ctx) =>
            {
                OnJumpPressed?.Invoke(true);
                Debug.Log("Jump Pressed");
            };
        }
        inputSystem.Player.Jump.performed += (ctx) => OnJumpPressed?.Invoke(true);
        inputSystem.Player.Jump.canceled += (ctx) => OnJumpPressed?.Invoke(false);


    }
    private void OnEnable()
    {
        inputSystem.Enable();
    }
    private void OnDisable()
    {
        inputSystem.Disable();
    }
   
}
