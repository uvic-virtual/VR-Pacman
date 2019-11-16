using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    /// <summary>
    /// Parent Gameobject to mark intersections of maze.</summary>
    [SerializeField] private GameObject NavigationMarkers;

    private NavMeshAgent agent;

    /// <summary>
    /// Iterable way to tell agent to move to next waypoint.</summary>
    private IEnumerator Destinations;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Destinations = VisitPoints();
        Destinations.MoveNext();
    }

    private void Update()
    {
        //check if nav agent as arrived at current waypoint.
        if (AtDestination())
        {
            //move to next waypoint, or reset if at end.
            if (!Destinations.MoveNext())
            {
                Destinations = VisitPoints();
            }
        }
    }

    /// <summary>
    /// Go through all the points in the navigation waypoints.  
    /// Move next moves to next waypoint.
    /// </summary>
    /// <returns>Ienumerator for going to next waypoint.</returns>
    private IEnumerator VisitPoints()
    {
        var waypoints = NavigationMarkers.GetComponentsInChildren<Transform>();
        foreach (var waypoint in waypoints)
        {
            agent.SetDestination(waypoint.position);
            yield return null;
        }
    }

    /// <summary>
    /// Returns if the agent has reached it's destination.
    /// </summary>
    /// <returns></returns>
    private bool AtDestination()
    {
        return (Vector3.Distance(transform.position, agent.destination) < 0.5f);

        //copied from the internet.  maybe tinker to get to work?
        return agent.pathPending && 
               agent.remainingDistance <= agent.stoppingDistance &&
               (!agent.hasPath || agent.velocity.sqrMagnitude == 0f);
    }
}
