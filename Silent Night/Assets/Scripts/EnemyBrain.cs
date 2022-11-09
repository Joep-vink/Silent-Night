using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    
    private float PlayerRange;

    private void Update()
    {
        if (PlayerRange < 10 )
        {
            GetComponent<EnemyWander>().StartWander();
        }
        else
        {
            GetComponent<EnemyFollow>().StartFollow();
        }
    }
}
