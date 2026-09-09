using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform CameraTransform;
    [SerializeField,Range(0,2)] float Sensitivity =2.5f;
    float angel;
   public void Look(Vector2 lookDirection)
    {
        transform.Rotate(Vector3.up, lookDirection.x * Sensitivity);
        angel -= lookDirection.y * Sensitivity;
        angel = Mathf.Clamp(angel, -90f, 90f);
        CameraTransform.localRotation = Quaternion.Euler(angel, 0, 0);
    }
}
