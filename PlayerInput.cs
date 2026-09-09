using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
  

    InputSystem_Actions inputSystem;
    public MovementConfig movementConfig = new MovementConfig();

    private void Awake()
    {
        inputSystem = new InputSystem_Actions();
        inputSystem.Player.Move.performed += (InputAction.CallbackContext ctx) =>
        {
            movementConfig.wishDirection = ctx.ReadValue<Vector2>();
        };
        inputSystem.Player.Look.performed += (InputAction.CallbackContext ctx) =>
        {
            movementConfig.lookDirection = ctx.ReadValue<Vector2>();
            
        };

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
