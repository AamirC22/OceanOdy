using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 5f; // Speed of the stingray's movement
    public Transform[] waypoints; // Points between which the stingray will move

    private int currentWaypointIndex = 0; // Index of the current waypoint target
    private bool movingForward = true; // Direction of movement

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if the stingray has reached the waypoint
        if (transform.position == targetWaypoint.position)
        {
            if (movingForward)
            {
                // Increment the waypoint index
                if (currentWaypointIndex < waypoints.Length - 1)
                    currentWaypointIndex++;
                else
                {
                    // Change direction and decrement the index
                    movingForward = false;
                    currentWaypointIndex--;
                }
            }
            else
            {
                // Decrement the waypoint index
                if (currentWaypointIndex > 0)
                    currentWaypointIndex--;
                else
                {
                    // Change direction and increment the index
                    movingForward = true;
                    currentWaypointIndex++;
                }
            }
        }

        // Rotate the stingray to face the next waypoint
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }
}
 