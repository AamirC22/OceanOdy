using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkChase : MonoBehaviour
{
    public float chaseSpeed = 5f;
    public float chaseTriggerDistance = 10f;
    // Removed the startPosition from Inspector as it's now hardcoded in Start

    private GameObject player;
    private bool isChasing;
    private Vector3 originalPosition; // To remember the original start position

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Gamer");
        isChasing = false;

        // Hardcoded start position based on the parent's world position
        originalPosition = transform.parent.position + new Vector3(228.5f, 74.25999f, -303.6802f);

        // Move the shark to the start position at the beginning of the game
        transform.position = originalPosition;
    }

    void Update()
    {
        if (player == null) return;

        // Measure the distance from the player to the shark's original position (cave)
        float distanceToPlayerFromOriginalPosition = Vector3.Distance(player.transform.position, originalPosition);

        if (distanceToPlayerFromOriginalPosition <= chaseTriggerDistance)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            // Only chase if the shark is not already at the player's position to prevent overshooting
            if ((transform.position - player.transform.position).sqrMagnitude > 0.1f)
            {
                MoveTowards(player.transform.position);
            }
            else
            {
                // If the shark is very close to the player, it can stop moving and just turn to face the player
                LookAtLastKnownPlayerPosition();
            }
        }
        else
        {
            // When not chasing, return to the original position
            if ((transform.position - originalPosition).sqrMagnitude > 0.1f)
            {
                MoveTowards(originalPosition);
            }
            else
            {
                LookAtLastKnownPlayerPosition();
            }
        }
    }

    void LookAtLastKnownPlayerPosition()
    {
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        if (directionToPlayer != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            // Rotate over time based on chaseSpeed to make it smooth
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * chaseSpeed);
        }
    }

    void MoveTowards(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, chaseSpeed * Time.deltaTime);

        Vector3 direction = (target - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
