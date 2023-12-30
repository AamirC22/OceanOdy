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
            _health = value;
            if (_health <= 0)
            {
                SceneManager.LoadScene("DeathScene");
            }
        }
    }
    public TextMeshProUGUI HealthBarText;

    void Update()
    {
        HealthBarText.text = "Health: " + _health.ToString("D3");
    }
}