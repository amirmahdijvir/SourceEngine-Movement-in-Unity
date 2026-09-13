using System;
using UnityEngine;

[System.Serializable]
public class MovementConfig
{
    
    public float wishSpeed = 5;
    public float ACCELERATE = 10;
    public float AIR_ACCELERATE = 10;
    public float FRICTION = 4;
    public Vector2 lookDirection { get; set; }
    public Vector3 wishDirection { get; set; }
    public Vector3 velocity { get; set; }
}
