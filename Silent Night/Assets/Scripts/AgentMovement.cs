using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody rb;

    protected Vector3 movementDirection;
   
    [field: SerializeField]
    public MovementDataSO CrouchData { get; set; }
    [field: SerializeField]
    public MovementDataSO WalkData { get; set; }
    [field: SerializeField]
    public MovementDataSO RunData { get; set; }

    [Header("Debug")]
    [SerializeField]
    protected float currentVelocity = 0;

    [field: SerializeField]
    public bool IsRunning { get; private set; } = false;
    [field: SerializeField]
    public bool IsCrouching { get; private set; } = false;

    private MovementDataSO currentMovementData;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentMovementData = WalkData;
    }

    private void Update()
    {
        if (IsCrouching)
            currentMovementData = CrouchData;
        else if (IsRunning)
            currentMovementData = RunData;
        else
            currentMovementData = WalkData;
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection.normalized * currentVelocity;
    }

    public void MoveAgent(Vector3 movementInput)
    {
        if (movementInput.magnitude > 0)
            movementDirection = transform.forward * movementInput.z + transform.right * movementInput.x;
            
        currentVelocity = CalculateSpeed(movementInput, currentMovementData.walkAcceleration, currentMovementData.walkDeacceleration, currentMovementData.maxWalkSpeed);
    }

    private float CalculateSpeed(Vector3 movementInput, float _acceleration, float _deacceleration, float _maxSpeed)
    {
        if (movementInput.magnitude > 0)
            currentVelocity += _acceleration * Time.deltaTime;
        else
            currentVelocity -= _deacceleration * Time.deltaTime;

        return Mathf.Clamp(currentVelocity, 0, _maxSpeed);
    }
}