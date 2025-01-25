using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public RoomLevel levelPrefab;
    public const float levelStep = 6f;
    public float levelOffset = levelStep;

    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> chars = new List<GameObject>();


    private System.Random random = new System.Random();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    public RoomLevel GenerateStartLevel()
    {
        var level = GenerateLevel(false);
        level.HideWalls();
        return level;
    }

    public RoomLevel GenerateLevel(bool fillRooms)
    {
        var level = Instantiate<RoomLevel>(levelPrefab, new Vector3(0, levelOffset, 0), Quaternion.Euler(0, 0, 0));
        levelOffset -= levelStep;

        if (fillRooms)
        {
            for(int i = 0; i<3; i++)
            {
                Room room = null;
                if (i == 0)
                {
                    room = level.room1;
                }
                if (i == 1)
                {
                    room = level.room2;
                }
                if (i == 2)
                {
                    room = level.room3;
                }

                int roomHasItem = random.Next(5);
                if (roomHasItem == 0 || roomHasItem ==1) continue;
                
                if (roomHasItem == 2 || roomHasItem == 3)
                {
                    room.mainSlot.itemSlot.item = GenerateRandomItem(room.mainSlot.transform.position);
                }
                if (roomHasItem == 4)
                {
                    room.combatSlot2.character = GenerateRandomChar(room.combatSlot2.transform.position);
                }
            }

            int hasDoorOnFloor = random.Next(2);
            if (hasDoorOnFloor == 1)
            {
                int doorBetweenRoom = random.Next(2);
                if (doorBetweenRoom == 0)
                {
                    level.door1.Close();
                }
                if (doorBetweenRoom == 1)
                {
                    level.door2.Close();
                }
            }

            
        }

        return level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item GenerateRandomItem(Vector3 position)
    {
        int index = random.Next(items.Count);

        return Instantiate(items[index], position, Quaternion.Euler(0, 0, 0)).GetComponent<Item>();
    }

    private Char GenerateRandomChar(Vector3 position)
    {
        int index = random.Next(chars.Count);

        return Instantiate(chars[index], position, Quaternion.Euler(0, 0, 0)).GetComponent<Char>();
    }

}
