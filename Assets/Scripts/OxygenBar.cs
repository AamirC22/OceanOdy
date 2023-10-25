using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OxygenBar : MonoBehaviour
{
    private int OxygenLevel = 500;
    public TextMeshProUGUI OxygenBarText;
    public LayerMask waterLayer;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Gamer");
        if (player == null)
        {
            Debug.LogError("Player object not found. Make sure it has the 'Gamer' tag.");
        }
        else
        {
            StartCoroutine(DecreaseOxygen());
        }
    }

    IEnumerator DecreaseOxygen()
    {
        OxygenBarText.text = "Oxygen: " + OxygenLevel.ToString("D3");
        while (OxygenLevel > 0)
        {
            Vector3 playerPosition = player.transform.position + Vector3.up * 0.1f;

            if (playerPosition.y < 30)
            {
                OxygenBarText.text = "Oxygen: " + OxygenLevel.ToString("D3");
                OxygenLevel -= 1;
            }
            else
            {
                // Player is not in the water layer, you can handle this case if needed
            }

            Debug.Log("Oxygen Level: " + OxygenLevel); // Debug statement to track the OxygenLevel
            yield return new WaitForSecondsRealtime(1f);
        }
            SceneManager.LoadScene("OxygenDepleted");
    }
}