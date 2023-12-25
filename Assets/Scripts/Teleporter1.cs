using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter1 : MonoBehaviour
{
    public GameObject Player;
    public GameObject TeleportTo;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Teleporter1"))
        {
            Player.transform.position = TeleportTo.transform.position;
        }
    }
}
