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

        // Rotate stingray
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
        if (timeSinceLastHit < hitCooldown)
        {
            timeSinceLastHit += Time.deltaTime;
        }
        if (timeSinceLastKnockback < knockbackCooldown)
        {
            timeSinceLastKnockback += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision) // Checks if player collides with enemy, if collided - health decreases
    {
        if (collision.gameObject.tag == "Gamer")
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            playerHealthBar.Health -= 25;
            Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;
            knockbackDirection.y = 0;
            playerRigidbody.AddForce(knockbackDirection * knockbackStrength, ForceMode.Impulse);
            timeSinceLastHit = 0f;
            timeSinceLastKnockback = 0f;
           
        }
        else
        {
            Debug.Log("Collided with non player object.");
        }
    }
}