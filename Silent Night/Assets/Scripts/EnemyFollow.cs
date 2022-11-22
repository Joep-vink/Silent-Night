using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == true)
        {
            SceneManager.LoadScene(2);
        }
    }
}
