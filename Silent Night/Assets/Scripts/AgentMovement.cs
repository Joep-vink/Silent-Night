using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody rb;

    protected Vector3 movementDirection;

    [field: SerializeField]
    public MovementDataSO MovementData { get; set; }

    [Header("Debug")]
    [SerializeField]
    protected float currentVelocity = 0;
    [field: SerializeField]
    public bool IsRunning { get; private set; } = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection.normalized * currentVelocity;
    }

    public void MoveAgent(Vector3 movementInput)
    {
        if (movementInput.magnitude > 0)
            movementDirection = transform.forward * movementInput.z + transform.right * movementInput.x;

        if (IsRunning)
            currentVelocity = CalculateSpeed(movementInput, MovementData.runkAcceleration, MovementData.runDeacceleration, MovementData.maxRunSpeed);
        else
            currentVelocity = CalculateSpeed(movementInput, MovementData.walkAcceleration, MovementData.walkDeacceleration, MovementData.maxWalkSpeed);
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