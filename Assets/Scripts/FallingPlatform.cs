using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    bool isFalling = false;
    float downSpeed = 0;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Gamer"))
        {
            isFalling = true;
            
        }
    }

    void Update()
    {
         if(isFalling)
        {
            downSpeed += Time.deltaTime/20;
            transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed, transform.position.z);
        }
    }
}
