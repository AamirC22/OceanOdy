using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleportSound : MonoBehaviour
{
    [SerializeField] private AudioSource teleportSound;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Gamer"))
        {
            // Play the teleport sound effect
            teleportSound.Play();
        }
    }
}
