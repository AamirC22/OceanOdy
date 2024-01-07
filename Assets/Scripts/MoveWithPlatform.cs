using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject playerObject1;
    public GameObject playerObject2;
    public GameObject playerObject3;
    public GameObject playerObject4;
    public GameObject platformObject;

    private bool isPlayerOnPlatform = false;

    void OnTriggerEnter(Collider collider) // Checks if player enters the platform box collider, sets variable to true
    {
        if (collider.CompareTag("Gamer"))
        {
            isPlayerOnPlatform = true;
        }
    }

    void OnTriggerExit(Collider collider) // Checks if player enters the platform box collider, sets variable to false
    {
        if (collider.CompareTag("Gamer"))
        {
            isPlayerOnPlatform = false;
        }
    }

    void Update() // Checks if player is on platform
    {
        if (isPlayerOnPlatform)
        {
            // Update the player objects' positions based on the platform's position
            Vector3 platformPosition = platformObject.transform.position;
            playerObject.transform.position = new Vector3(playerObject.transform.position.x, platformPosition.y, playerObject.transform.position.z);
            playerObject1.transform.position = new Vector3(playerObject1.transform.position.x, platformPosition.y, playerObject1.transform.position.z);
            playerObject2.transform.position = new Vector3(playerObject2.transform.position.x, platformPosition.y, playerObject2.transform.position.z);
            playerObject3.transform.position = new Vector3(playerObject3.transform.position.x, platformPosition.y, playerObject3.transform.position.z);
            playerObject4.transform.position = new Vector3(playerObject4.transform.position.x, platformPosition.y, playerObject4.transform.position.z);
        }
    }
}
