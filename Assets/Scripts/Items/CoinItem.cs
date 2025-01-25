using UnityEngine;

public class CoinItem : MonoBehaviour, Item
{
    

    public void DoAction(Char character, Manager manager)
    {
        manager.soundController.PlayCoinSound();
        manager.coins++;
        manager.uiController.SetCoinsText(manager.coins);
        manager.RemoveCollectedItem();
        Destroy(this.gameObject);
    }
}
