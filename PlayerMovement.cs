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
        GroundMove(movementConfig.wishDirection, movementConfig.wishSpeed);
       
    }
    private void GroundMove(Vector3 wishDirection,float wishSpeed)
    {
        ApplyFriction();
        Vector3 wishDir = (transform.forward * wishDirection.y + transform.right * wishDirection.x).normalized;

        Debug.Log(characterController.velocity.magnitude);
        float currentSpeed = Vector3.Dot(movementConfig.velocity, wishDir);
        float addSpeed = wishSpeed - currentSpeed;
        if (addSpeed > 0)
        {
            float accelSpeed = movementConfig.ACCELERATE * wishSpeed * Time.deltaTime;
            accelSpeed = Mathf.Min(accelSpeed, addSpeed);
            movementConfig.velocity += accelSpeed * wishDir;
        }
        characterController.Move(movementConfig.velocity * Time.deltaTime);
    }
    private void ApplyFriction() 
    {
        float speed = movementConfig.velocity.magnitude;
        if(speed < 0.1f)
        {
            movementConfig.velocity = Vector3.zero;
            return;
        }
        float drop = speed * movementConfig.FRICTION * Time.deltaTime;
        float newSpeed = Mathf.Max(speed - drop, 0);
        movementConfig.velocity *= newSpeed / speed;
    }


}
