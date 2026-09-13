using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform CameraTransform;
    [SerializeField,Range(0,80)] float Sensitivity =20f;
    float angel;
   public void Look(Vector2 lookDirection)
    {
        transform.Rotate(Vector3.up, lookDirection.x * Sensitivity * Time.deltaTime);
        angel -= lookDirection.y * Sensitivity * Time.deltaTime;
        angel = Mathf.Clamp(angel, -90f, 90f);
        CameraTransform.localRotation = Quaternion.Euler(angel, 0, 0);
    }
}
