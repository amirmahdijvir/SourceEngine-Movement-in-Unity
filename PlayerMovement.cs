using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    MovementConfig movementConfig;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    public void MoveUpdate(MovementConfig movementConfig)
    {
        this.movementConfig = movementConfig;
        Gravity();

        bool grounded = characterController.isGrounded;

        if (grounded)
            GroundMove(movementConfig.wishDirection, movementConfig.wishSpeed);
        else
            AirMove(movementConfig.wishDirection, movementConfig.airSpeed);

        if (movementConfig.bunnyhop)
        {
            
            HandleJump();
        }
        else if (grounded)
        {
            HandleJump();
        }

    }


    // Ground movement logic for when the player is on the ground
    private void GroundMove(Vector3 wishDirection,float wishSpeed)
    {
        // Apply friction when the player is on the ground and not jumping
        if (!movementConfig.isJumpPressed)
            ApplyFriction();

        // Calculate the desired movement direction based on the player's input and orientation
        Vector3 wishDir = (transform.forward * wishDirection.y + transform.right * wishDirection.x).normalized;

        // Calculate the current speed in the desired direction
        float currentSpeed = Vector3.Dot(movementConfig.velocity, wishDir);

        // Calculate the additional speed needed to reach the desired speed
        float addSpeed = wishSpeed - currentSpeed;

        // If additional speed is needed, accelerate the player in the desired direction
        if (addSpeed > 0)
        {
            // Calculate the acceleration speed based on the configured acceleration and time delta
            float accelSpeed = movementConfig.ACCELERATE * wishSpeed * Time.deltaTime;
            // Limit the acceleration speed to the additional speed needed
            accelSpeed = Mathf.Min(accelSpeed, addSpeed);
            // Update the player's velocity by adding the acceleration in the desired direction
            movementConfig.velocity += accelSpeed * wishDir;
        }
        // Move Player
        characterController.Move(movementConfig.velocity * Time.deltaTime);
     
    }

    // Air movement logic for when the player is in the air
    private void AirMove(Vector3 wishDirection, float airSpeed)
    {
        // Calculate the desired movement direction based on the player's input and orientation
        Vector3 wishDir = (transform.forward * wishDirection.y + transform.right * wishDirection.x).normalized;

        // Calculate the current speed in the desired direction
        float currentSpeed = Vector3.Dot(movementConfig.velocity, wishDir);

        // Calculate the additional speed needed to reach the desired speed
        float addSpeed = airSpeed - currentSpeed;

        // If additional speed is needed, accelerate the player in the desired direction
        if (addSpeed > 0)
        {
            // Calculate the acceleration speed based on the configured air acceleration and time delta
            float accelSpeed = movementConfig.AIR_ACCELERATE * airSpeed * Time.deltaTime;

            // Limit the acceleration speed to the additional speed needed
            accelSpeed = Mathf.Min(accelSpeed, addSpeed);

            // Update the player's velocity by adding the acceleration in the desired direction
            movementConfig.velocity += accelSpeed * wishDir;
        }
        // Move Player
        characterController.Move(movementConfig.velocity * Time.deltaTime);
    }
    private void ApplyFriction() 
    {
        // Find the horizontal velocity (ignoring vertical movement)
        Vector3 horizontalVel = new Vector3(movementConfig.velocity.x, 0, movementConfig.velocity.z);
        // Calculate the speed of the horizontal velocity
        float speed = horizontalVel.magnitude;

        // If the speed is very low, stop the player to prevent sliding
        if (speed < 0.1f)
        {
            // Stop the player completely if the speed is below a threshold
            movementConfig.velocity.x = 0;
            movementConfig.velocity.z = 0;
            return;
        }
        // Calculate the amount of speed to drop based on friction and time
        float drop = speed * movementConfig.FRICTION * Time.deltaTime;

        // Calculate the new speed after applying friction, ensuring it doesn't go below zero
        float newSpeed = Mathf.Max(speed - drop, 0);

        // Scale the horizontal velocity to the new speed while maintaining direction
        float scale = newSpeed / speed;

        // Apply the scaled horizontal velocity back to the player's velocity
        movementConfig.velocity.x *= scale;
        movementConfig.velocity.z *= scale;
    }



    private void Gravity()
    {
        if (characterController.isGrounded && movementConfig.velocity.y < 0)
        {
            movementConfig.velocity.y = -2f; 
            return;
        }
        movementConfig.velocity.y -= movementConfig.gravity * Time.deltaTime;
    }
    private void HandleJump()
    {
        if (!characterController.isGrounded || !movementConfig.isJumpPressed)
            return;

        movementConfig.velocity.y = movementConfig.jumpForce;

        if (!movementConfig.bunnyhop)
        {
            movementConfig.isJumpPressed = false;
        }
    }


}
