using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private int _health = 100;
    public Slider healthSlider; // Reference to the Slider component for the health bar

    public int Health
    {
        get { return _health; }
        set
        {
            _health = Mathf.Max(value, 0); // Ensure health doesn't go below 0

            // Check if healthSlider is not null before trying to set its value
            if (healthSlider != null)
            {
                healthSlider.value = _health; // Update the slider's value when the health changes
            }
            else
            {
                Debug.LogError("Health slider reference is null.");
            }

            // Check if health is 0 or less to handle player death
            if (_health <= 0)
            {
                SceneManager.LoadScene("DeathScene");
            }
        }
    }

    void Start()
    {
        // Check if healthSlider is not null before setting its maxValue and value
        if (healthSlider == null)
        {
            Debug.LogError("HealthBar Error: Slider component not found on " + gameObject.name);
        }
        else
        {
            healthSlider.maxValue = _health; // Set the slider's max value to the player's max health
            healthSlider.value = _health; // Set the slider's current value to the player's current health
        }

    }
}
