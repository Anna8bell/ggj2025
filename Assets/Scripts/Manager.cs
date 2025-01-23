using UnityEngine;

public class Manager : MonoBehaviour
{
    public Char hero;
    private LevelBuilder levelBuilder;
    public RoomLevel currentLevel;
    public RoomLevel nextLevel;

    public Dragon dragon;
    public GameObject fireWall;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelBuilder = GetComponent<LevelBuilder>();
        currentLevel = levelBuilder.GenerateStartLevel();
        nextLevel = levelBuilder.GenerateLevel();

        hero.gameObject.transform.position = currentLevel.room1.mainSlot.transform.position;
        dragon.gameObject.transform.position = currentLevel.room3.mainSlot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
