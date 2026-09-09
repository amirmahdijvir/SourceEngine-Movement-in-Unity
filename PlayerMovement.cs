using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

  
}
