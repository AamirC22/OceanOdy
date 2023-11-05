using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;
    Vector3 originalPosition;
    float timeToReset = 10.0f; // Adjust this to control how long it takes to reset the platform.
    float timer = 0.0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Gamer"))
        {
            isFalling = true;
        }
    }

    void Update()
    {
        if (isFalling)
        {
            downSpeed += Time.deltaTime / 20;
            transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed, transform.position.z);

            if (transform.position.y < originalPosition.y - 10.0f) // Adjust -2.0f to your desired falling distance.
            {
                isFalling = false;
                downSpeed = 0;
            }
        }
        else if (timer < timeToReset)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // Reset the platform to its original position.
            transform.position = originalPosition;
            timer = 0.0f;
        }
    }
}