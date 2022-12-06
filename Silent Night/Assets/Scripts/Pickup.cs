using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform Thedest;
    public bool holding;

    private void Update()
    {
        if (holding)
        {
            this.transform.position = Thedest.position;
        }
       
    }

    public void OnMouseButton()
    {
        holding =! holding;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    public void OnMouseUp()
    {
        holding = false;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<SphereCollider>().enabled = true;
    }
}
