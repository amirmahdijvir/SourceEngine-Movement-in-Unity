using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerCamera))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMovement))]
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
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCamera.Look(movementConfig.lookDirection);
        playerMovement.MoveUpdate(movementConfig);
    }
}
