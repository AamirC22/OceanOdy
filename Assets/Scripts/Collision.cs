using System.Runtime.InteropServices;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other) // Triggers when Player collides with Coin object
    {
        if (!isCollected && other.CompareTag("Gamer"))
        {
            isCollected = true; // Ensure that this coin only gets collected once
            Destroy(gameObject); // Destroys coin when collided with

            if (CoinCount.Instance != null)
            {
                CoinCount.Instance.UpdateCoinCount(1); // Updates coin count 
            }
        }
    }
}
