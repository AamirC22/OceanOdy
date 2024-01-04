using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject showPauseMenu;
    public GameObject oxygenBarFill;
    public GameObject oxygenBarOutline;
    public GameObject oxygenBarIcon;
    public GameObject showHealthBar;
    public GameObject showCoins;
    public GameObject settingsPanel;
    public GameObject settingsBTN;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                if (settingsPanel.activeSelf == true) {
                    settingsPanel.SetActive(false);
                }
                resumeGame();
            }
            else
            {
                settingsBTN.SetActive(true);
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
        SetImageEnabled(oxygenBarFill.GetComponent<Image>(), true); // makes oxygen bar visible
        SetImageEnabled(oxygenBarOutline.GetComponent<Image>(), true); //
        SetImageEnabled(oxygenBarIcon.GetComponent<Image>(), true); //
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
        SetImageEnabled(oxygenBarFill.GetComponent<Image>(), false); // makes oxygen bar invisible
        SetImageEnabled(oxygenBarOutline.GetComponent<Image>(), false); //
        SetImageEnabled(oxygenBarIcon.GetComponent<Image>(), false); //
        showCoins.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void SetImageEnabled(Image image, bool isEnabled)
    {
        image.enabled = isEnabled;
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
