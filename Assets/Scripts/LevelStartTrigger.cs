using UnityEngine;

public class LevelStartTrigger : MonoBehaviour
{
    private bool hasTimerStarted = false;

    void Start()
    {
        // ensures that the timer only started once
        if (!hasTimerStarted)
        {
            GameTimer.instance.BeginGame();
            hasTimerStarted = true;
        }
    }
}
