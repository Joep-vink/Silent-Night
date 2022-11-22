using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public int Coins;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("coin erbij");
            Coins = Coins + 1;
            Destroy(other.gameObject);
        }

        if (Coins == 3)
        {
            SceneManager.LoadScene(1);
        }
    }


}
