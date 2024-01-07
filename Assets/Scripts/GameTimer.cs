using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public static GameTimer instance;

    private float startTime;
    private float elapsedTime;
    private bool isRunning;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }

    public void BeginGame()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
        elapsedTime = 0f;
    }

    public void PauseTimer()
    {
        isRunning = false;
        elapsedTime += Time.time - startTime;
    }

    public void ResumeTimer()
    {
        if (!isRunning)
        {
            startTime = Time.time;
            isRunning = true;
        }
    }

    public void StopTimer()
    {
        if (isRunning)
        {
            elapsedTime += Time.time - startTime;
            isRunning = false;
        }
    }

    public float GetElapsedTime()
    {
        if (isRunning)
        {
            return elapsedTime + (Time.time - startTime);
        }
        else
        {
            return elapsedTime;
        }
    }

    void Update()
    {
        if (isRunning)
        {
            float currentTime = GetElapsedTime();
            string minutes = ((int)(currentTime / 60)).ToString("00");
            string seconds = (currentTime % 60).ToString("00.00");
        }
    }
}
