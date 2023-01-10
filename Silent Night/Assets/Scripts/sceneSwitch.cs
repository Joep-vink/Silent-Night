using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    public bool TpAfterXAmount = false;

    public Transform PlayerTransform;
    public Transform Teleportinside;
    public Transform TeleportOutside;

    private void Start()
    {
        if (TpAfterXAmount)
        {
            StartCoroutine(SwitchScene());
        }
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "outside")
        {
            PlayerTransform.position = Teleportinside.position;
            AudioManager.instance.Play("door");
        }

        if (other.gameObject.tag == "inside")
        {
            PlayerTransform.position = TeleportOutside.position;
            AudioManager.instance.Play("door");
        }

    }

}
