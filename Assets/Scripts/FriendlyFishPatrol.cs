using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyFishPatrol : MonoBehaviour
{
    public float speed = 5.0f;
    public float orbitDistance = 20.0f; 
    public float orbitDegreesPerSec = 30.0f; 
    private Vector3 orbitPoint; 

    private Vector3 previousPosition;

    void Start() 
    {
        orbitPoint = transform.position; // orbits around this point
        previousPosition = orbitPoint + (transform.forward * orbitDistance);
        transform.position = previousPosition;
    }

    void Update() // moves fish in a circle based on orbit point and degrees per sec
    {
        Vector3 offset = transform.position - orbitPoint;
        Vector3 newPosition = orbitPoint + (Quaternion.Euler(0, orbitDegreesPerSec * Time.deltaTime, 0) * offset.normalized) * orbitDistance;
        transform.position = newPosition;
        Vector3 movementDirection = (newPosition - previousPosition).normalized;
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
        }
        previousPosition = newPosition;
    }
}
