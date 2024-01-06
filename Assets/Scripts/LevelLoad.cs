using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public string chosenLevel;
    public Animator newTransition;
    public void LoadChosenLevel()
    {
        StartCoroutine(waitForAnimation(chosenLevel));
    }

    IEnumerator waitForAnimation(string ChosenLevel)
    {
        newTransition.SetTrigger("start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(chosenLevel);
    }
}
