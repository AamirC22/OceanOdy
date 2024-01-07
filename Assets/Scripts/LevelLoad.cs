using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public Animator newTransition; // allows animation to be added

    IEnumerator waitForAnimation() // trigger to start animation, waits for 2 seconds
    {
        newTransition.SetTrigger("start");
        yield return new WaitForSeconds(2);
    }

    public void LoadInstructions() // calls coroutine and loads instructions scene
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("Instructions");
    }


    public void LoadMainMenu()
    { // calls coroutine and loads main menu
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadPlatform1() // calls coroutine and loads level 1
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("Platform1");
    }

    public void LoadLevel2() // calls coroutine and loads level 2
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("Level2");
    }

    public void LoadDeathScene() // calls coroutine and loads death scene
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("DeathScene");
    }

    public void LoadOxygenDepleted() // calls coroutine and loads oxygen depleted scene
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("OxygenDepleted");
    }

    public void LoadWinningScene() // calls coroutine and loads winning scene
    {
        StartCoroutine(waitForAnimation());
        SceneManager.LoadScene("WinningScene");
    }
}
