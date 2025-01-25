using UnityEngine;

public class KeyItem : MonoBehaviour, Item
{
  
    public void DoAction(Char character, Manager manager)
    {
        manager.soundController.PlayPickUpSound();
        manager.keys++;
        manager.uiController.SetKeysText(manager.keys);
        manager.RemoveCollectedItem();
        Destroy(this.gameObject);
    }
}
