using System;
using UnityEngine;

[System.Serializable]
public class MovementConfig
{
    public bool bunnyhop = false;
    public bool isJumpPressed;

    public float gravity = 15;
    public float jumpForce = 6.5f;
    public float wishSpeed = 15;
    public float airSpeed = 1;
    public float ACCELERATE = 5.5f;
    public float AIR_ACCELERATE = 250;
    public float FRICTION = 5.2f;
    public Vector2 lookDirection { get; set; }
    public Vector3 wishDirection { get; set; }
    public Vector3 velocity;
}
