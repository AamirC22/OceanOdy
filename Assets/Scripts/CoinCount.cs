using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCount : MonoBehaviour
{
    public int coinCount = 0;
    public TextMeshProUGUI coinCountText;
    public static CoinCount Instance;

    void Start()
    {
        Instance = this; 
    }


    // Update is called once per frame
    void Update()
    {
        coinCountText.text = "Coins: " + coinCount.ToString("D1") + " /4";
        if(coinCount == 4)
        {
            SceneManager.LoadScene("WinningScene");
        }
    }

    public void UpdateCoinCount(int value)
    {
        coinCount += value;
        coinCountText.text = "Coins: " + coinCount.ToString("D1") + " /4";
    }
}
