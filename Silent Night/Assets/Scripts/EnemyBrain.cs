using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EnemyState
{
    Wander,
    Follow,
}

public class EnemyBrain : MonoBehaviour
{
    public float PlayerRange;
    public GameObject Player;

    public EnemyState enemyState;
    private EnemyWander enemyWander;
    private EnemyFollow enemyFollow;

    private void Start()
    {
        enemyWander = GetComponent<EnemyWander>();
        enemyFollow = GetComponent<EnemyFollow>();
    }

    private void Update()
    {
        UpdateStates(enemyState);
    }


    public void UpdateStates(EnemyState newState)
    {
        switch (newState)
        {
            case EnemyState.Wander:
                if (Vector3.Distance(transform.position, Player.transform.position) > PlayerRange)
                {
                    enemyWander.StartWander();
                }
                else
                {
                    enemyState = EnemyState.Follow;
                }
                break;
            case EnemyState.Follow:
                if (Vector3.Distance(transform.position, Player.transform.position) < PlayerRange)
                {
                    enemyFollow.StartFollow();
                }
                else
                {
                    enemyState = EnemyState.Wander;
                }
                break;
        }



    }

    public void OntriggerEnter(Collider coll)
    {
        if (coll.gameObject == true)
        {
            SceneManager.LoadScene(2);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject = gameObject)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, PlayerRange);
            Gizmos.color = Color.white;
        }
    }
#endif


    /*public GameObject Player;

    public float PlayerRange;

    private EnemyWander enemyWander;
    private EnemyFollow enemyFollow;

    private void Start()
    {
       enemyWander = GetComponent<EnemyWander>();
       enemyFollow = GetComponent<EnemyFollow>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) > PlayerRange )
        {
            enemyWander.StartWander();
            enemyFollow.followPlayer = false;
            Debug.Log("wander");
        }
        else
        {
            enemyFollow.StartFollow();
            Debug.Log("follow");
        }
    }

    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject = gameObject)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, PlayerRange);
            Gizmos.color = Color.white;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            Debug.Log("dead");
        }
    }*/


}
