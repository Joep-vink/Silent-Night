using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Agent/MovementData")]
public class MovementDataSO : ScriptableObject
{
    [Header("Walk Stats")]
    [Range(1, 10)]
    public float maxWalkSpeed = 5;
    [Range(0.1f, 10)]
    public float walkAcceleration = 5, walkDeacceleration = 5;
    
    [Header("Run Stats")]
    [Range(5, 15)]
    public float maxRunSpeed = 7;
    [Range(0.1f, 10)]
    public float runkAcceleration = 5, runDeacceleration = 5;
}
