using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform Thedest;
    public bool holding;

    public float delay;
    private float timer;

    private void Start()
    {
        timer = delay;
    }

    private void Update()
    {
        if (holding)
        {
            this.transform.position = Thedest.position;
            timer -= Time.deltaTime;

            if (timer <= 0 && Input.GetMouseButtonDown(0))
            {
                holding = false;
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().velocity = Vector2.zero;
                GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    private void OnMouseDown()
    {
        if (!holding)
        {
            timer = delay;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector2.zero;
            this.transform.parent = GameObject.Find("Destination").transform;
            holding = true;
        }
    }
}
