using System;
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

    [field: SerializeField]
    public float currentVelocity { get; private set; }

    [HideInInspector]
    public MovementDataSO currentMovementData;
    public bool isCrouched { get; private set; }

    [Header("Stamina")]
    public float MaxStamina;
    public float TiredSpeed;
    public float GainSpeed;
    public float stamina;
    public bool CanRun = true;

    private void Start()
    {
        stamina = MaxStamina;
        rb = GetComponent<Rigidbody>();
        currentMovementData = WalkData;
    }

    private void Update()
    {
        NewStamina();
    }

    private void NewStamina()
    {
        Mathf.Clamp(stamina, 0, MaxStamina);

        if (Input.GetKey(KeyCode.LeftShift) && CanRun)
        {
            if (stamina <= 0)
            {
                CanRun = false;
            }
         
            stamina -= Time.deltaTime * TiredSpeed;
        }
        else
        {
            stamina += Time.deltaTime * GainSpeed;
        }
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