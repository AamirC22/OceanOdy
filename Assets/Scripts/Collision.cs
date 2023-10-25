using System.Runtime.InteropServices;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gamer"))
        {

            Destroy(gameObject);
            
            if (CoinCount.Instance != null)
            {
                CoinCount.Instance.UpdateCoinCount(1);
                
            }


        }
    }
}