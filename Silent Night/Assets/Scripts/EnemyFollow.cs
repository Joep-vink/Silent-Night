using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent enemy;

    public Transform PlayerTarget;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    public void StartFollow()
    {
        enemy.SetDestination(PlayerTarget.position);
    }
}
