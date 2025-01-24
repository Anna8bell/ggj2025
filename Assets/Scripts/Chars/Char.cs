using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public Room currentRoom;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToSideRoom(Room room)
    {
        currentRoom = room;
        transform.position = room.mainSlot.transform.position;
        //TODO  Animation
        //make queue that mast be empty until next action can be sent
    }

    public void MoveDown(Room room)
    {
        currentRoom = room;
        transform.position = room.mainSlot.transform.position;
        //TODO  Animation
        //make queue that mast be empty until next action can be sent
    }

    public void Fight(Char enemy)
    {

    }

    public bool CanGoRight()
    {
        return currentRoom.right != null;
    }

    public bool CanGoLeft()
    {
        return currentRoom.left != null;
    }

    public Char CanFight(List<Char> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].currentRoom == currentRoom)
            {
                return enemies[i];
            }
        }
        return null;
    }

}
