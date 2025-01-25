using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public GameObject menu;
    public GameObject gameplay;
    public GameObject gameOver;
    public TMP_Text coinsText;
    public TMP_Text keysText;
    public TMP_Text enemiesText;

    public Manager manager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
        gameplay.SetActive(false);
        gameOver.SetActive(false);
    }

    public void ShowGameplay()
    {
        menu.SetActive(false);
        gameplay.SetActive(true);
        gameOver.SetActive(false);
        SetCoinsText(manager.coins);
        SetKeysText(manager.keys);
        SetEnemiesText(manager.enemies);
    }

    public void ShowGameOver()
    {
        menu.SetActive(false);
        gameplay.SetActive(false);
        gameOver.SetActive(true);
    }

    public void SetCoinsText(int coins)
    {
        coinsText.text = "Coins: " + coins;
    }

    public void SetKeysText(int keys)
    {
        keysText.text = "Keys: " + keys;
    }

    public void SetEnemiesText(int enemies)
    {
        enemiesText.text = "Enemies Left: " + enemies;
    }
}
