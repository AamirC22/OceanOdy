using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;
    Vector3 originalPosition;
    float timeToReset = 10.0f;
    float timer = 0.0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnTriggerEnter(Collider collider) // checks if player collided with platform
    {
        if (collider.CompareTag("Gamer"))
        {
            isFalling = true;
        }
    }

    void Update()
    {
        if (isFalling) // checks if platform is falling after player collides, transforms position
        {
            downSpeed += Time.deltaTime / 20;
            transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed, transform.position.z);

            if (transform.position.y < originalPosition.y - 50.0f)
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
            transform.position = originalPosition; // brings platform back to original position
            timer = 0.0f;
        }
    }
}