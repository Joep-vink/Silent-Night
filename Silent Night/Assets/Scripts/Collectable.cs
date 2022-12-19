using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public int Coins;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("coin erbij");
            Coins = Coins + 1;
            DontDestroyOnLoad(this.gameObject);
        }

        if (Coins == 5)
        {
            SceneManager.LoadScene(1);
        }
    }

    
}
