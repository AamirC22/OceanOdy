using UnityEngine;
using TMPro;

public class VictoryScene : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText;

    private void Start()
    {
        if (GameTimer.instance != null)
        {
            finalTimeText.text = "You completed the game in " + FormatElapsedTime(GameTimer.instance.GetElapsedTime()); 
        }
    }

    private string FormatElapsedTime(float elapsedTime) // formats the time
    {
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
