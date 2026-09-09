using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    CharacterController characterController;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

  
}
