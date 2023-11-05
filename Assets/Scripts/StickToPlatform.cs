using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject platformObject;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Gamer"))
        {
            //set playerObject as child of parentObject
            playerObject.transform.parent = platformObject.transform;
            UnityEngine.Debug.Log("Gamer collided with Horizontal Cube");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Gamer"))
        {
            playerObject.transform.parent = null;
            UnityEngine.Debug.Log("Gamer stopped colliding");
        }
    }
}
   
