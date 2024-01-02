using System.Runtime.InteropServices;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Gamer"))
        {
            isCollected = true; // Ensure that this coin only gets collected once
            Destroy(gameObject);

            if (CoinCount.Instance != null)
            {
                CoinCount.Instance.UpdateCoinCount(1);
            }
        }
    }
}
