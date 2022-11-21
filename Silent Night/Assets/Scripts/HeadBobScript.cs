using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobScript : MonoBehaviour
{
    [SerializeField]
    private bool enable = true;
    [SerializeField, Range(0, 0.1f)]
    private float amplitude = 0.15f;
    [SerializeField, Range(0, 30f)]
    private float frequency = 10;

    [SerializeField]
    private Transform camera;
    [SerializeField]
    private Transform cameraHolder;

    float toggleSpeed = 3;
    Vector3 startPos;
    AgentMovement movement;

    private void Start()
    {
        movement = GetComponent<AgentMovement>();
        startPos = camera.localPosition;
    }

    private void Update()
    {
        if (!enable) return;

        CheckMotion();
        ResetPosition();
    }

    Vector3 FootStepMotion()
    {
        Vector3 _pos = Vector3.zero;
        _pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        _pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        return _pos;
    }

    void PlayMotion(Vector3 _motion)
    {
        camera.localPosition += _motion;
    }

    public void CheckMotion()
    {
        if (movement.currentVelocity != 0)
            PlayMotion(FootStepMotion());
    }

    void ResetPosition()
    {
        if (camera.localPosition == startPos) return;
        camera.localPosition = Vector3.Lerp(camera.localPosition, startPos, 1 * Time.deltaTime);
    }
}
