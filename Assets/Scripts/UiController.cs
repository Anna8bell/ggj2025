using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public GameObject menu;
    public GameObject gameplay;
    public TMP_Text coinsText;
    public TMP_Text keysText;

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
    }

    public void ShowGameplay()
    {
        menu.SetActive(false);
        gameplay.SetActive(true);
        SetCoinsText(manager.coins);
        SetKeysText(manager.keys);
    }

    public void SetCoinsText(int coins)
    {
        coinsText.text = coins + "";
    }

    public void SetKeysText(int keys)
    {
        keysText.text = keys + "";
    }
}
