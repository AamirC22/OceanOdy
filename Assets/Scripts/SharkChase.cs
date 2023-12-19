using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkChase : MonoBehaviour
{
    public float speed = 5.0f; // Speed at which the shark moves in the orbit
    public float orbitDistance = 20.0f; // The radius of the orbit
    public float orbitDegreesPerSec = 30.0f; // The speed of the orbit in degrees per second
    public Vector3 orbitPoint; // The point around which the shark will orbit

    private Vector3 previousPosition; // To store the position from the previous frame

    void Start()
    {
        // Initialize the shark's position on the orbit
        previousPosition = transform.position;
    }

    void Update()
    {
        // Calculate the next position in the orbit
        Vector3 newPosition = orbitPoint + (Quaternion.Euler(0, orbitDegreesPerSec * Time.deltaTime, 0) * (transform.position - orbitPoint).normalized) * orbitDistance;

        // Move the shark to the new position
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
