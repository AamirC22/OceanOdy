using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public Animator newTransition;

    IEnumerator waitForAnimation()
    {
        newTransition.SetTrigger("start");
        yield return new WaitForSeconds(2);
    }

    public void LoadInstructions()
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("Instructions");
    }


    public void LoadMainMenu()
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadPlatform1()
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("Platform1");
    }

    public void LoadLevel2()
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("Level2");
    }

    public void LoadDeathScene()
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("DeathScene");
    }

    public void LoadOxygenDepleted()
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("OxygenDepleted");
    }

    public void LoadWinningScene()
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("WinningScene");
    }
}
