using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void RestartTheGame() // loads level 1
    {
        SceneManager.LoadScene("Platform1");
    }

    public void ShowGameInstructions() // shows instructions
    {
        SceneManager.LoadScene("Instructions");
    }
}
