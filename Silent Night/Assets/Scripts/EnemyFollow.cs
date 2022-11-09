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

    private void Update()
    {
        enemy.SetDestination(PlayerTarget.position);
    }

    public void StartFollow()
    {
        Update();
    }
}
