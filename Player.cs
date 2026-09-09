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
    MovementConfig movementConfig;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerCamera = GetComponent<PlayerCamera>();
        movementConfig = playerInput.movementConfig;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCamera.Look(movementConfig.lookDirection);
    }
}
