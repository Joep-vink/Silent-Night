using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Collectable : MonoBehaviour
{
    public int Coins;
    public  TextMeshProUGUI countText;
    private int count;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("coin erbij");
            Coins = Coins + 1;
            DontDestroyOnLoad(this.gameObject);
            AudioManager.instance.Play("wendigo");
            SetCountText();
        }

        if (Coins == 6)
        {
            SceneManager.LoadScene(1);
        }
    }

    void SetCountText()
    {
        countText.text = "Coins " + Coins.ToString() + "/5";
    }

}
