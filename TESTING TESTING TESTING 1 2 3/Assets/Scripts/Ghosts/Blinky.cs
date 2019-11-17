using UnityEngine;

/// <summary>
/// Implements Blinky (Red)'s movement behavior.
/// He agressively chases after the player by targeting the waypoint in front of the player.</summary>
public class Blinky : GhostMovement
{
    protected override Vector3 GetNextChaseDestination()
    {
        return Player.transform.position;
    }
}
