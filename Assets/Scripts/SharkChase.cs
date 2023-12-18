using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkChase : MonoBehaviour
{
    public float speed = 5.0f; // Speed at which the shark moves

    private GameObject player; // To hold the reference to the player

    void Start()
    {
        // Find the player GameObject by tag
        player = GameObject.FindGameObjectWithTag("Gamer");
    }

    void Update()
    {
        if (player != null)
        {
            // Look at the player
            transform.LookAt(player.transform);

            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
