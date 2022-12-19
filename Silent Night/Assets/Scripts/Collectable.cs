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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("coin erbij");
            Coins = Coins + 1;
        }

        if (Coins == 5)
        {
            SceneManager.LoadScene(1);
        }
    }

    
}
