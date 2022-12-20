using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform Teleportinside;
    public Transform TeleportOutside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "outside")
        {
            PlayerTransform.position = Teleportinside.position;

        }

        if (other.gameObject.tag == "inside")
        {
            PlayerTransform.position = TeleportOutside.position;
        }

    }
}
