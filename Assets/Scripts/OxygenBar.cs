using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider slider; // Reference to the Slider component - used for UI
    public TextMeshProUGUI oxygenText;
    public LevelLoad levelLoad;

    void Start()
    {
        SetMaxOxygen(750); // Set the maximum (starting) oxygen level
        StartCoroutine(DecreaseOxygen()); // Start the coroutine to decrease oxygen over time
    }

    // Coroutine to decrease oxygen level over time
    IEnumerator DecreaseOxygen()
    {
        while (slider.value > 0)
        {
            yield return new WaitForSeconds(1); // Wait for 1 second
            SetOxygen((int)slider.value - 1); // decrease oxygen by 1
        }
        levelLoad.LoadOxygenDepleted();
    }

    // Method to set the current oxygen level
    public void SetOxygen(int oxygen)
    {
        slider.value = oxygen;
    }

    // Method to set the maximum oxygen level
    public void SetMaxOxygen(int oxygen)
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;
    }
}