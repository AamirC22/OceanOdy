using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleportSound : MonoBehaviour
{
    [SerializeField] private AudioSource teleportSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gamer"))
        {
            teleportSound.Play(); // plays sound effect
        }
    }
}
