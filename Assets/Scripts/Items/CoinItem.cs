using UnityEngine;

public class CoinItem : MonoBehaviour, Item
{
    private AudioSource sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoAction(Char character, Manager manager)
    {
        sound.Play();
        manager.coins++;
        manager.uiController.SetCoinsText(manager.coins);
        manager.RemoveCollectedItem();
        Destroy(this.gameObject);
    }
}
