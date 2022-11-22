using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX, sensY;
    [Range(1,10)]
    public float crouchSpeed = 5;

    public Transform cameraHolder, orientation;
    public Transform standPos, crouchPos;

    float xRotation;
    AgentMovement movement;

    private void Start()
    {
        movement = GetComponentInParent<AgentMovement>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (movement.isCrouched)
            transform.position = new Vector3(orientation.position.x, Mathf.Lerp(transform.position.y, crouchPos.position.y, Time.deltaTime * crouchSpeed), orientation.position.z);
        else
            transform.position = new Vector3(orientation.position.x, Mathf.Lerp(transform.position.y, standPos.position.y, Time.deltaTime * crouchSpeed), orientation.position.z);

        float _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        xRotation -= _mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localEulerAngles = Vector3.right * xRotation;

        orientation.Rotate(Vector3.up * _mouseX);
    }
}
