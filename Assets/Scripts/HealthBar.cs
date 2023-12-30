using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private int _health = 100;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = Mathf.Max(value, 0); // Ensure health doesn't go below 0
            HealthBarText.text = "Health: " + _health.ToString("D3"); // Update the UI when the health value changes
            if (_health <= 0)
            {
                SceneManager.LoadScene("DeathScene");
            }
        }
    }
    public TextMeshProUGUI HealthBarText;

    void Start()
    {
        // Ensure the UI reflects the initial health value when the game starts
        HealthBarText.text = "Health: " + _health.ToString("D3");
    }


}
