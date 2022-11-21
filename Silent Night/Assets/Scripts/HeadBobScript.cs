using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobScript : MonoBehaviour
{
    [SerializeField]
    private bool enable = true;

    [SerializeField]
    private Transform camera;

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
        _pos.x += Mathf.Cos(Time.time * movement.currentMovementData.frequency / 2) * movement.currentMovementData.amplitude * 2;
        _pos.y += Mathf.Sin(Time.time * movement.currentMovementData.frequency) * movement.currentMovementData.amplitude;
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
