using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider slider; // Reference to the Slider component
    public TextMeshProUGUI oxygenText; // Reference to the TextMeshPro component

    // Start is called before the first frame update
    void Start()
    {
        SetMaxOxygen(1000); // Set the maximum oxygen level to 1000 at the start
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
        // If oxygen level is 0, load the 'OxygenDepleted' scene
        SceneManager.LoadScene("OxygenDepleted");
    }

    // Method to set the current oxygen level
    public void SetOxygen(int oxygen)
    {
        slider.value = oxygen;
        //UpdateOxygenText(); // Update the oxygen text
    }

    // Method to set the maximum oxygen level
    public void SetMaxOxygen(int oxygen)
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;
        //UpdateOxygenText(); // Update the oxygen text
    }

    // Method to update the oxygen text
    private void UpdateOxygenText()
    {
        oxygenText.text = "Oxygen: " + slider.value.ToString();
    }
}


/*
// Oxygen level variables
private float oxygen;
private float maxOxygen = 1000f;
private float oxygenDecreaseRate = 100f; // Amount of oxygen to decrease per second

// UI elements for oxygen
public TextMeshProUGUI OxygenBarText;
public Image oxygenBar; // Reference to the Image component representing the oxygen bar
public Text oxygenText; // Reference to the Text component displaying the oxygen level as text

private void Start()
{
    // Set the initial oxygen level
    oxygen = maxOxygen;

    // Start the coroutine to decrease oxygen over time
    StartCoroutine(DecreaseOxygen());
}

private void Update()
{
    // Update the UI elements every frame
    oxygenText.text = "Oxygen: " + Mathf.RoundToInt(oxygen) + "%";
    oxygenBar.fillAmount = oxygen / maxOxygen;
}

private IEnumerator DecreaseOxygen()
{
    // Loop as long as there is oxygen remaining
    while (oxygen > 0)
    {
        // Decrease the oxygen level
        oxygen -= oxygenDecreaseRate;
        yield return new WaitForSecondsRealtime(1f);

        // Check if oxygen has run out
        if (oxygen <= 0)
        {
            // Load the scene for when oxygen is depleted
            SceneManager.LoadScene("OxygenDepleted");
        }
    }
}

// Optional: Function to decrease oxygen from other sources (e.g., enemy attack)
public void LoseOxygen(float decreaseAmount)
{
    oxygen = Mathf.Max(oxygen - decreaseAmount, 0); // Ensure oxygen does not go below zero
}
*/