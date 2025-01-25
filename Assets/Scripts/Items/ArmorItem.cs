using UnityEngine;

public class ArmorItem : MonoBehaviour, Item
{
    
    public void DoAction(Char character, Manager manager)
    {
        manager.soundController.PlayPickUpSound();
        character.OnEquipFound(Char.Equip.Armor);
        manager.RemoveCollectedItem();
        Destroy(this.gameObject);
    }

}
