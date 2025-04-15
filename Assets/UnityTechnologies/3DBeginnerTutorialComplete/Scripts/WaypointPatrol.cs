using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public float normalSpeed = 1f;
    public float spottedMultiplier = 1.5f;
    public float fovDotThreshold = 0.8f; // 37 degree vision cone
    public float detectionRange = 10f; // can see within this range

    private Transform player;
    int m_CurrentWaypointIndex;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        navMeshAgent.speed = normalSpeed;

        // Cache player reference
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) player = p.transform;
        else Debug.LogError("No object tagged 'Player' found.");
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 toPlayer = player.position - transform.position;
            float distance = toPlayer.magnitude;

            if (distance <= detectionRange)
            {
                toPlayer.Normalize();
                float dot = Vector3.Dot(transform.forward, toPlayer);

                if (dot > fovDotThreshold)
                {
                    navMeshAgent.speed = normalSpeed * spottedMultiplier;
                }
                else
                {
                    navMeshAgent.speed = normalSpeed;
                }
            }
            else
            {
                navMeshAgent.speed = normalSpeed;
            }
        }

        // Patrol logic
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}