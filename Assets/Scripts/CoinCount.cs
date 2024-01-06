using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCount : MonoBehaviour
{
    public int coinCount = 0;
    //public TextMeshProUGUI coinCountText;
    public static CoinCount Instance;
    public LevelLoad levelLoad;

    [SerializeField] private AudioSource CoinSound;
    public Image[] coinImages; // Reference to the UI coin outlines

    void Start()
    {
        Instance = this;
        UpdateCoinUI(); // update the UI on start
    }

    void Update()
    {
        if (coinCount == 4)
        {
            if (SceneManager.GetActiveScene().name == "Platform1")
            {
                levelLoad.LoadLevel2();
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                levelLoad.LoadWinningScene();
            }
        }
    }

    public void UpdateCoinCount(int value)
    {
        CoinSound.Play();
        coinCount += value;
        //coinCountText.text = "Coins: " + coinCount.ToString("D1") + " /4";
        UpdateCoinUI(); // Update the coin UI whenever the coin count changes
    }

    private void UpdateCoinUI()
    {
        for (int i = 0; i < coinImages.Length; i++)
        {
            coinImages[i].enabled = i < coinCount; // enables the image if the index is less than the coin count
        }
    }
}
