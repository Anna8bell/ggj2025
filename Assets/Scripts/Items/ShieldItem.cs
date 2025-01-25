using UnityEngine;

public class ShieldItem : MonoBehaviour, Item
{

    public void DoAction(Char character, Manager manager)
    {
        manager.soundController.PlayPickUpSound();
        character.OnEquipFound(Char.Equip.Shield);
        manager.RemoveCollectedItem();
        Destroy(this.gameObject);
    }

}
