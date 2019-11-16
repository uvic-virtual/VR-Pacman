using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    /// <summary>
    /// "Constant" for checking if ghost has reached destination. </summary>
    [SerializeField] private float DestinationDistanceCheck = 0.5f;
   
    /// <summary>
    /// Parent Gameobject to mark intersections of maze.</summary>
    [SerializeField] private GameObject NavigationMarkers;
    private List<Transform> WaypointList;

    private NavMeshAgent agent;

    /// <summary>
    /// Iterable way to tell agent to move to next waypoint.</summary>
    private IEnumerator<Transform> Waypoints;  

    private void Start()
    {
        //Get list of waypoints minus parent.
        WaypointList = NavigationMarkers.GetComponentsInChildren<Transform>().Where(child => child.parent != null).ToList();

        //Get enumerable thing of waypoints
        Waypoints = WaypointList.GetEnumerator();
        Waypoints.MoveNext();

        //set agent destination to first waypoint.
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Waypoints.Current.position);
    }

    private void Update()
    {
        //check if nav agent as arrived at current waypoint.
        if (AtDestination())
        {
            if (!Waypoints.MoveNext())
            {
                Waypoints = WaypointList.GetEnumerator();
                Waypoints.MoveNext();
            }
            agent.SetDestination(Waypoints.Current.position);
        }
    }

    //Returns true if the agent has reached it's destination.
    private bool AtDestination()
    {
        return (Vector3.Distance(transform.position, agent.destination) < DestinationDistanceCheck);

        //copied from the internet.  maybe tinker to get to work?
        //return agent.pathPending && 
        //       agent.remainingDistance <= agent.stoppingDistance &&
        //       (!agent.hasPath || agent.velocity.sqrMagnitude == 0f);
    }
}
