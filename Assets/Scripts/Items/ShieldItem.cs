using UnityEngine;

public class ShieldItem : MonoBehaviour, Item
{

    public void DoAction(Char character, Manager manager)
    {
        character.OnEquipFound(Char.Equip.Shield);
        manager.RemoveCollectedItem();
        Destroy(this.gameObject);
    }

}
