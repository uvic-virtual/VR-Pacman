using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GhostMovement : MonoBehaviour
{
    [SerializeField] private float DestinationDistanceCheck = 0.5f;

    [SerializeField] private List<Transform> ScatterPoints;

    private IEnumerator<Transform> ScatterEnumerator;

    protected static List<GameObject> Waypoints;

    protected static GameObject Player;

    private NavMeshAgent Agent;

    public enum State { Chase, Frightened, Scatter };

    public static State CurrentState;

    private void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        if (Waypoints == null)
        {
            Waypoints = GameObject.FindGameObjectsWithTag("Waypoint").ToList();
        }
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        bool AtDestination = Vector3.Distance(transform.position, Agent.destination) < DestinationDistanceCheck;

        if (AtDestination)
        {
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
            int randomIndex = Random.Range(0, Waypoints.Count);
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

}
