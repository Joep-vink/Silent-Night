using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody rb;

    [SerializeField] protected float currentVelocity = 0;
    protected Vector3 movementDirection;

    [field: SerializeField]
    public MovementDataSO MovementData { get; set; }

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
        
        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector3 movementInput)
    {
        if (movementInput.magnitude > 0)
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        else
            currentVelocity -= MovementData.deacceleration * Time.deltaTime;
        
        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }
}
