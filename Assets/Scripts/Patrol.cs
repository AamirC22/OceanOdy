using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] waypoints;
    public float knockbackStrength = 10f;
    public HealthBar playerHealthBar;

    private int currentWaypointIndex = 0;
    private bool movingForward = true;
    private float timeSinceLastHit = 0f;  // Timer to track time since last hit
    public float hitCooldown = 1f;  // Cooldown duration in seconds


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

        // Increment the time since last hit
        if (timeSinceLastHit < hitCooldown)
        {
            timeSinceLastHit += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);

        if (collision.gameObject.tag == "Gamer")
        {
            Debug.Log("It's the player!");

            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;
                knockbackDirection.y = 0; // Ensure we don't apply knockback in the Y axis
                playerRigidbody.AddForce(knockbackDirection * knockbackStrength, ForceMode.Impulse);
                Debug.Log("Player knocked back.");

                // Check if cooldown has passed before applying damage again
                if (timeSinceLastHit >= hitCooldown)
                {
                    if (playerHealthBar != null)
                    {
                        playerHealthBar.Health -= 25;
                        Debug.Log("Player health after hit: " + playerHealthBar.Health);
                        // Reset the timer
                        timeSinceLastHit = 0f;
                    }
                    else
                    {
                        Debug.LogError("PlayerHealthBar reference is not set in the Patrol script.");
                    }
                }
                else
                {
                    Debug.Log("Hit cooldown in progress. Time since last hit: " + timeSinceLastHit);
                }
            }
            else
            {
                Debug.LogError("No Rigidbody component found on the player!");
            }
        }
        else
        {
            Debug.Log("Collision with non-player object.");
        }
    }

}
