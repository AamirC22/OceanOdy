using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the desired object
        if (collision.gameObject.CompareTag("PirateCoin")) // is pirate coin the game tag?
        {
            // make obj invisible
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
            {
                rend.enabled = false;
            }

            gameObject.SetActive(false);
        }
    }
}
