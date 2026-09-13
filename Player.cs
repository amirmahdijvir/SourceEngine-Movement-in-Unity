using UnityEngine;


// Add the required components to the Player GameObject
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerCamera))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    PlayerCamera playerCamera;
    PlayerInput playerInput;
    PlayerMovement playerMovement;
    MovementConfig movementConfig;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        playerCamera = GetComponent<PlayerCamera>();
        movementConfig = playerInput.movementConfig;
        playerInput.OnJumpPressed += (isPressed) => movementConfig.isJumpPressed = isPressed;
    }

    void Update()
    {
        
        playerInput.bunnyHop = movementConfig.bunnyhop;
        playerCamera.Look(movementConfig.lookDirection);
        playerMovement.MoveUpdate(movementConfig);
    }
}
