using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    enemyWander.StartWander();
                else
                {
                    enemyState = EnemyState.Follow;
                }
                break;
            case EnemyState.Follow:
                if (Vector3.Distance(transform.position, Player.transform.position) < PlayerRange)
                    enemyFollow.StartFollow();
                else
                {
                    enemyState = EnemyState.Wander;
                }
                break;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, PlayerRange);
            Gizmos.color = Color.white;
        }
    }
#endif
}
