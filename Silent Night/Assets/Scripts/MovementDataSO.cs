using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Agent/MovementData")]
public class MovementDataSO : ScriptableObject
{
    [Range(1, 10)]
    public float maxWalkSpeed = 5;
    [Range(0.1f, 10)]
    public float walkAcceleration = 5, walkDeacceleration = 5;
}
