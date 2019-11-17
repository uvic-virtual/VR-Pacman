using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GhostMovement : MonoBehaviour
{
    [SerializeField] private float DestinationDistanceCheck = 0.5f;

    [SerializeField] private List<Transform> ScatterPoints;

    public enum State { Chase, Frightened, Scatter };

    public static State CurrentState;

    private static GameObject Player;

    private NavMeshAgent Agent;

    private void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        bool AtDestination = Vector3.Distance(transform.position, Agent.destination) < DestinationDistanceCheck;
        
        if (AtDestination)
        {
            Agent.SetDestination(NextDestination());
        }
    }

    protected abstract Vector3 NextDestination();
}
