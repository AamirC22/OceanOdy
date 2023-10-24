using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private int Health = 100;
    public TextMeshProUGUI HealthBarText;


    // Update is called once per frame
    void Update()
    {
        HealthBarText.text = "Health: " + Health.ToString("D3");
        if(Health == 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
