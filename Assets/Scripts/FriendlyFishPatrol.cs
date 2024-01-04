using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyFishPatrol : MonoBehaviour
{
    public float speed = 5.0f; // Speed at which the fish moves in the orbit
    public float orbitDistance = 20.0f; // The radius of the orbit
    public float orbitDegreesPerSec = 30.0f; // The speed of the orbit in degrees per second
    private Vector3 orbitPoint; // The point around which the fish will orbit, now private

    private Vector3 previousPosition; // To store the position from the previous frame

    void Start()
    {
        // Use the fish's starting position as the orbit point
        orbitPoint = transform.position;

        // Move the fish to the start of the orbit based on the orbit distance
        previousPosition = orbitPoint + (transform.forward * orbitDistance);
        transform.position = previousPosition;
    }

    void Update()
    {
        // Calculate the next position in the orbit
        Vector3 offset = transform.position - orbitPoint;
        Vector3 newPosition = orbitPoint + (Quaternion.Euler(0, orbitDegreesPerSec * Time.deltaTime, 0) * offset.normalized) * orbitDistance;

        // Move the fish to the new position
        transform.position = newPosition;

        // Look in the direction of the movement
        Vector3 movementDirection = (newPosition - previousPosition).normalized;
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
        }

        // Update previousPosition for the next frame
        previousPosition = newPosition;
    }
}
