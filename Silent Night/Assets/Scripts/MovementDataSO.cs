using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Agent/MovementData")]
public class MovementDataSO : ScriptableObject
{
    [Header("Movement")]
    [Range(1, 10)]
    public float maxWalkSpeed = 5;
    [Range(0.1f, 10)]
    public float walkAcceleration = 5, walkDeacceleration = 5;
    
    [Header("Camera")]
    [Range(0, 0.1f)]
    public float amplitude = 0.15f;
    [Range(0, 30f)]
    public float frequency = 10;
}
