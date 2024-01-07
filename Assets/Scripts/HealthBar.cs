using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private int _health = 100;
    public Slider healthSlider;
    public LevelLoad levelLoad;

    public int Health
    {
        get { return _health; }
        set
        {
            _health = Mathf.Max(value, 0);

            // checks if slider has error
            if (healthSlider != null)
            {
                healthSlider.value = _health; // updates slider if health changed
            }
            else
            {
                Debug.LogError("Health slider reference is null");
            }

            // if health below or equal to 0, loads death scene
            if (_health <= 0)
            {
                levelLoad.LoadDeathScene();
            }
        }
    }

    void Start() // sets values for health , checks for errors with slider
    {
        // Check if healthSlider is not null before setting its maxValue and value
        if (healthSlider == null)
        {
            Debug.LogError("Health slider reference is null");
        }
        else
        {
            healthSlider.maxValue = _health; // Set slider's max value to player's max health
            healthSlider.value = _health; // Set slider's current value to player's current health
        }

    }
}
