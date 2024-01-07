using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCount : MonoBehaviour
{
    public int coinCount = 0;
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
        if (coinCount == 4) // checks if coin count is 4 then loads according level
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

    public void UpdateCoinCount(int value) // plays sound when coin collected and increases count
    {
        CoinSound.Play();
        coinCount += value;
        UpdateCoinUI(); // Update the coin UI whenever the coin count changes
    }

    private void UpdateCoinUI() // updates UI if coin count changed
    {
        for (int i = 0; i < coinImages.Length; i++)
        {
            coinImages[i].enabled = i < coinCount; // enables the image if the index is less than the coin count
        }
    }
}
