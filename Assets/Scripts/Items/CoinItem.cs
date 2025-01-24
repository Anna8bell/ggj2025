using UnityEngine;

public class CoinItem : MonoBehaviour, Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoAction(Char character, Manager manager)
    {
        manager.coins++;
        manager.uiController.SetCoinsText(manager.coins);
        manager.RemoveCollectedItem();
        Destroy(this.gameObject);
    }
}
