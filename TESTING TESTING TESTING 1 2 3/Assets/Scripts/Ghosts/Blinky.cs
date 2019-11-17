using UnityEngine;

/// <summary>
/// Implements Blinky (Red)'s movement behavior.
/// He agressively chases after the player by targeting the waypoint in front of the player.</summary>
public class Blinky : GhostMovement
{
    protected override Vector3 NextDestination()
    {
        if (CurrentState == State.Chase)
        {
            return Vector3.zero;
        }
        else if (CurrentState == State.Frightened)
        {
            return Vector3.zero;
        }
        return Vector3.zero;
    }
}
