using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "outside")
        {
            SceneManager.LoadScene(2);
            DontDestroyOnLoad(this.gameObject);
        }

        if (other.gameObject.tag == "inside")
        {
            SceneManager.LoadScene(0);
            Destroy(this.gameObject);
        }

    }
}
