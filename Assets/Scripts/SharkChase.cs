using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkChase : MonoBehaviour
{
    public float chaseSpeed = 5f;
    public float chaseTriggerDistance = 10f;
    public float bitingRange = 2f; 
    public HealthBar playerHealthBar; 

    public AudioSource normalMusic; 
    public AudioSource horrorMusic; 

    private GameObject player;
    private bool isChasing;
    private Vector3 originalPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Gamer");
        isChasing = false;
        originalPosition = transform.parent.position + new Vector3(228.5f, 74.25999f, -303.6802f);
        transform.position = originalPosition;


        horrorMusic.Stop(); 
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        float distanceToPlayerFromOriginalPosition = Vector3.Distance(player.transform.position, originalPosition);

        // if the player is within chase range and the shark is not currently chasing
        if (distanceToPlayerFromOriginalPosition <= chaseTriggerDistance && !isChasing)
        {
            StartChase();
        }
        // if the player is outside chase range and the shark is currently chasing
        else if (distanceToPlayerFromOriginalPosition > chaseTriggerDistance && isChasing)
        {
            StopChase();
        }

        if (isChasing)
        {
            if (distanceToPlayer > bitingRange) // check if outside of biting range
            {
                MoveTowards(player.transform.position);
            }
            else
            {
                // if within biting range, reduce health to 0 and trigger death
                playerHealthBar.Health = 0;
            }
        }
        else
        {
            // when not chasing, return to the original position
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

    void StartChase() // plays music for chasing and sets chasing to true
    {
        isChasing = true;
        normalMusic.Stop();
        horrorMusic.volume = PlayerPrefs.GetFloat("musicVolume", 1f); 
        horrorMusic.Play(); 
    }

    void StopChase() // stops music for chasing and sets chasing to false
    {
        isChasing = false;
        horrorMusic.Stop(); 
        normalMusic.volume = PlayerPrefs.GetFloat("musicVolume", 1f); 
        normalMusic.Play(); 
    }



    void LookAtLastKnownPlayerPosition() // faces the shark to player
    {
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        if (directionToPlayer != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * chaseSpeed);
        }
    }

    void MoveTowards(Vector3 target) // shark moves towards player 
    {
        transform.position = Vector3.MoveTowards(transform.position, target, chaseSpeed * Time.deltaTime);

        Vector3 direction = (target - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}