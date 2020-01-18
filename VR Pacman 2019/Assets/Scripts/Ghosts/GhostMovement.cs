using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GhostMovement : MonoBehaviour
{
    [SerializeField] private float DestinationDistanceCheck = 0.5f;

    [SerializeField] private List<Transform> ScatterPoints;

    public enum State { Chase, Frightened, Scatter };

    public State CurrentState { get; private set; }

    private IEnumerator<Transform> ScatterEnumerator;

    protected static GameObject[] Waypoints;

    [SerializeField] protected GameObject Player;

    private NavMeshAgent Agent;

    private Vector3 PreviousDestination;

    private void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        if (Waypoints == null)
        {
            Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        }
        Agent = GetComponent<NavMeshAgent>();

        //Add delegates that change ghost's state to player 
        Pickup.Powerup += OnPlayerPowerUp;
        Pickup.Powerdown += OnPlayerPowerDown;
    }

    private void OnDestroy()
    {
        Pickup.Powerup -= OnPlayerPowerUp;
        Pickup.Powerdown -= OnPlayerPowerDown;
    }

    private void OnPlayerPowerUp()
    {
        Agent.SetDestination(PreviousDestination);
        CurrentState = State.Frightened;
    }

    private void OnPlayerPowerDown()
    {
        CurrentState = State.Chase;
    }

    private void Update()
    {
        bool AtDestination = Vector3.Distance(transform.position, Agent.destination) < DestinationDistanceCheck;

        if (AtDestination)
        {
            PreviousDestination = transform.position;
            Agent.SetDestination(GetNextDestination());
        }
    }

    
    private Vector3 GetNextDestination()
    {
        switch (CurrentState)
        {
            case State.Chase:
                return GetNextChaseDestination();

            case State.Frightened:
                int randomIndex = Random.Range(0, Waypoints.Length);
                return Waypoints[randomIndex].transform.position;

            case State.Scatter:
                if (!ScatterEnumerator.MoveNext())
                {
                    ScatterEnumerator = ScatterPoints.GetEnumerator();
                    ScatterEnumerator.MoveNext();
                }
                return ScatterEnumerator.Current.position;

            default:
                Debug.Log("Invalid ghost state");
                return PreviousDestination;
        }
    }

    protected abstract Vector3 GetNextChaseDestination();
}

