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
    public float CurrentStamina;
    public float MaxStamina;
    public float TiredSpeed;
    public float GainSpeed;

    private void Start()
    {
        CurrentStamina = MaxStamina;
        rb = GetComponent<Rigidbody>();
        currentMovementData = WalkData;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            CurrentStamina += Time.deltaTime * GainSpeed;
            currentMovementData = CrouchData;
            isCrouched = true;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && CurrentStamina > 0)
        {
            CurrentStamina -= Time.deltaTime * GainSpeed;
            isCrouched = false;
            currentMovementData = RunData;
        }
        else
        {
            CurrentStamina += Time.deltaTime * GainSpeed;
            currentMovementData = WalkData;
            isCrouched = false;
        }

        Mathf.Clamp(CurrentStamina, 0, MaxStamina);
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