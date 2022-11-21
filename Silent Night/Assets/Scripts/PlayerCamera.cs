using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX, sensY;

    public Transform cameraHolder, orientation;

    float xRotation, yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        xRotation -= _mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localEulerAngles = Vector3.right * xRotation;

        orientation.Rotate(Vector3.up * _mouseX);
    }
}
