using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 5f;
    public float knockbackStrength = 10f;
    public Transform[] waypoints;
    public HealthBar playerHealthBar;

    private int currentWaypointIndex = 0;
    private bool movingForward = true;
    private float timeSinceLastHit = 0f;
    private float timeSinceLastKnockback = 0f;
    public float hitCooldown = 1f;
    public float knockbackCooldown = 1f;

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (transform.position == targetWaypoint.position) // checks if at waypoint
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

        // rotates the stingray
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }

        // increase time since last hit
        if (timeSinceLastHit < hitCooldown)
        {
            timeSinceLastHit += Time.deltaTime;
        }

        // increase time since last knockback
        if (timeSinceLastKnockback < knockbackCooldown)
        {
            timeSinceLastKnockback += Time.deltaTime;
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
               
                if (timeSinceLastHit >= hitCooldown && timeSinceLastKnockback >= knockbackCooldown) // checks if cooldown has passed before applying knockback
                {
                    if (playerHealthBar != null)
                    {
                        playerHealthBar.Health -= 25;
                        Debug.Log("Player health after hit: " + playerHealthBar.Health);

                        // calculates and provides knockback force on player
                        Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;
                        knockbackDirection.y = 0; // constricts knockback to horizontal plane
                        playerRigidbody.AddForce(knockbackDirection * knockbackStrength, ForceMode.Impulse);

                        // Reset the timers
                        timeSinceLastHit = 0f;
                        timeSinceLastKnockback = 0f;
                    }
                    else
                    {
                        Debug.LogError("PlayerHealthBar reference is not set in the Patrol script.");
                    }
                }
                else
                {
                    Debug.Log("Cooldown in progress. Time since last hit: " + timeSinceLastHit + ", Time since last knockback: " + timeSinceLastKnockback);
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