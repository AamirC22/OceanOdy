using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject showPauseMenu;
    public GameObject showOxygenBar;
    public GameObject showHealthBar;
    public GameObject showCoins;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
        
    }

    public void resumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        showPauseMenu.SetActive(false);
        showHealthBar.SetActive(true);
        showOxygenBar.SetActive(true);
        showCoins.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void pauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        showPauseMenu.SetActive(true);
        showHealthBar.SetActive(false);
        showOxygenBar.SetActive(false);
        showCoins.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void loadMainMenu()
    {
        resumeGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
