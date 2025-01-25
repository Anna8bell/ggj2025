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
        var level = GenerateLevel();
        level.HideWalls();
        return level;
    }

    public RoomLevel GenerateLevel()
    {
        var level = Instantiate<RoomLevel>(levelPrefab, new Vector3(0, levelOffset, 0), Quaternion.Euler(0, 0, 0));
        levelOffset -= levelStep;

        level.room1.mainSlot.itemSlot.item = GenerateRandomItem(level.room1.mainSlot.transform.position);
        level.room2.mainSlot.itemSlot.item = GenerateRandomItem(level.room2.mainSlot.transform.position);

        //level.room3.mainSlot.itemSlot.item = GenerateRandomItem(level.room3.mainSlot.transform.position);
        level.room3.combatSlot2.character = GenerateRandomChar(level.room3.combatSlot2.transform.position);

        level.door2.Close();

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
