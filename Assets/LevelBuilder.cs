using System;
using UnityEngine;
using static UnityEngine.Rendering.GPUPrefixSum;

public class LevelBuilder : MonoBehaviour
{
    public RoomLevel levelPrefab;
    public const float levelStep = 6f;
    public float levelOffset = levelStep;

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

        return level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
