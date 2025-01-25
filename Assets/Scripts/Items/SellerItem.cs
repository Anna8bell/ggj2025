using UnityEngine;
using System.Collections;

public class SellerItem : MonoBehaviour, Item
{

    private MoveController moveController;
    private Constants constants;
    private LevelBuilder levelBuilder;
    public void DoAction(Char character, Manager manager)
    {
        moveController = manager.moveController;
        constants = manager.constants;
        levelBuilder = manager.levelBuilder;
        
        if (manager.coins > 0)
        {
            manager.MinusCoin();
            manager.soundController.PlayWelcomeSound();
            manager.soundController.PlayCoinSound();
            

            if (character.currentRoom.itemSlot1.itemSlot.item == null)
            {
                DropItemCoroutine(character.currentRoom.itemSlot1.itemSlot);
                return;
            }
            if (character.currentRoom.itemSlot2.itemSlot.item == null)
            {
                DropItemCoroutine(character.currentRoom.itemSlot2.itemSlot);
                return;
            }

            character.currentRoom.mainSlot.itemSlot.item = null;
            character.currentRoom.DefaultItemSelection();
             Destroy(gameObject);

            // Just steal money and Dissapear

        }
        
    }

    private void DropItemCoroutine(ItemSlot itemSlot)
    {
        var item = levelBuilder.GenerateRandomItem(itemSlot.transform.position);
        itemSlot.item = item;

    }

}
