using UnityEngine;

public class UiController : MonoBehaviour
{
    public GameObject menu;
    public GameObject gameplay;
    
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
    }
}
