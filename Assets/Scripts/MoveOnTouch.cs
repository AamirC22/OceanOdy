using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{

    public GameObject playerObject;
    public GameObject playerObject1;
    public GameObject playerObject2;
    public GameObject playerObject3;
    public GameObject playerObject4;
    public GameObject platformObject;

    void OnTriggerEnter(Collider collider) // if player collides with cube, sets it as child of platform object
    {
        if (collider.CompareTag("Gamer"))
        {
            //set playerObject as child of parentObject
            playerObject.transform.parent = platformObject.transform;
            playerObject1.transform.parent = platformObject.transform;
            playerObject2.transform.parent = platformObject.transform;
            playerObject3.transform.parent = platformObject.transform;
            playerObject4.transform.parent = platformObject.transform;
            UnityEngine.Debug.Log("Gamer has collided with horizontal cube");
        }
    }
}
