using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GhostMovement : MonoBehaviour
{
    [SerializeField] private float DestinationDistanceCheck = 0.5f;

    [SerializeField] private List<Transform> ScatterPoints;
    
    [SerializeField] protected GameObject Player;
   
    public enum State { Chase, Frightened, Scatter, Dead };

    public State CurrentState { get; private set; }

    protected GameObject[] Waypoints;

    protected Pickup PlayerPickup;

    private NavMeshAgent Agent;

    private Vector3 PreviousDestination;

    private IEnumerator<Transform> ScatterEnumerator;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPickup = Player.GetComponentInChildren<Pickup>();
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        Agent = GetComponent<NavMeshAgent>();

        //Add delegates that change ghost's state to player 
        PlayerPickup.Powerup += OnPlayerPowerUp;
        PlayerPickup.Powerdown += OnPlayerPowerDown;
    }
    
    private void Update()
    {
        //If at destination
        if (Vector3.Distance(transform.position, Agent.destination) < DestinationDistanceCheck)
        {
            PreviousDestination = transform.position;
            Agent.SetDestination(GetNextDestination());
        }
    }


    private Vector3 GetNextDestination()
    {
        if (CurrentState == State.Chase)
        {
            return GetNextChaseDestination();
        }
        else if (CurrentState == State.Frightened)
        {
            int randomIndex = Random.Range(0, Waypoints.Length);
            return Waypoints[randomIndex].transform.position;
        }
        else //state == Scatter
        {
            if (!ScatterEnumerator.MoveNext())
            {
                ScatterEnumerator = ScatterPoints.GetEnumerator();
                ScatterEnumerator.MoveNext();
            }
            return ScatterEnumerator.Current.position;
        }
    }
    
    protected abstract Vector3 GetNextChaseDestination();

    private void OnPlayerPowerUp()
    {
        Agent.SetDestination(PreviousDestination);
        CurrentState = State.Frightened;
    }

    private void OnPlayerPowerDown()
    {
        CurrentState = State.Chase;
    }
}

