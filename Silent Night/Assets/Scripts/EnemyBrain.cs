using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,
    Follow,
    Teleport
}

public class EnemyBrain : MonoBehaviour
{
    public float PlayerRange, TpRange;
    public GameObject Player;

    public EnemyState enemyState;
    private EnemyWander enemyWander;
    private EnemyFollow enemyFollow;

    [SerializeField]
    private bool showDebug = true;

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
                Wander();
                break;
            case EnemyState.Follow:
                Follow();
                break;
            case EnemyState.Teleport:
                Teleport();
                break;
        }
    }

    #region States
    void Wander()
    {
        enemyWander.StartWander();

        if (Vector3.Distance(transform.position, Player.transform.position) < PlayerRange)
            enemyState = EnemyState.Follow;
        else if (Vector3.Distance(transform.position, Player.transform.position) > TpRange)
            enemyState = EnemyState.Teleport;
    }

    void Follow()
    {
        enemyFollow.StartFollow();

        if (Vector3.Distance(transform.position, Player.transform.position) > PlayerRange)
            enemyState = EnemyState.Wander;
        else if (Vector3.Distance(transform.position, Player.transform.position) > TpRange)
            enemyState = EnemyState.Teleport;
    }

    void Teleport()
    {
        transform.position = Player.transform.position + new Vector3(10, transform.position.y);

        if (Vector3.Distance(transform.position, Player.transform.position) > PlayerRange)
            enemyState = EnemyState.Wander;
        else if (Vector3.Distance(transform.position, Player.transform.position) < PlayerRange)
            enemyState = EnemyState.Follow;
    }
    #endregion

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject && showDebug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, PlayerRange);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, TpRange);
        }
    }
#endif
}
