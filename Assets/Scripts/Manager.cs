using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    public Char hero;
    private LevelBuilder levelBuilder;
    private MoveController moveController;
    private Constants constants;

    public RoomLevel currentLevel;
    public RoomLevel nextLevel;

    public Dragon dragon;
    public GameObject fireWall;
    public List<Char> enemies = new List<Char>();

    public Camera camera;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelBuilder = GetComponent<LevelBuilder>();
        moveController = GetComponent<MoveController>();
        constants = GetComponent<Constants>();
        currentLevel = levelBuilder.GenerateStartLevel();
        nextLevel = levelBuilder.GenerateLevel();

        hero.gameObject.transform.position = currentLevel.room1.mainSlot.transform.position;
        hero.currentRoom = currentLevel.room1;

        dragon.gameObject.transform.position = currentLevel.room3.mainSlot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveController.CanDoNextMove()) 
            return;

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            if (hero.CanGoRight())
            {
                hero.MoveToSideRoom(hero.currentRoom.right);
            }
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            if (hero.CanGoLeft())
            {
                hero.MoveToSideRoom(hero.currentRoom.left);
            }
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            if (hero.currentRoom == currentLevel.room1)
            {
                hero.MoveDown(nextLevel.room1);
            }
            if (hero.currentRoom == currentLevel.room2)
            {
                hero.MoveDown(nextLevel.room2);
            }
            if (hero.currentRoom == currentLevel.room3)
            {
                hero.MoveDown(nextLevel.room3);
            }

            SwitchLevel();
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var enemy = hero.CanFight(enemies);
            if (enemy != null)
            {
                hero.Fight(enemy);
            }
        }
    }

    private void SwitchLevel()
    {
        currentLevel = nextLevel;
        nextLevel = levelBuilder.GenerateLevel();

        StartCoroutine(MoveCameraCoroutine(new Vector3(camera.transform.position.x, currentLevel.transform.position.y - 6, camera.transform.position.z)));
    }

    private IEnumerator MoveCameraCoroutine(Vector3 position)
    {
        //print("MoveCameraCoroutine started");

        float time = 0;
        var target = position;
        var done = false;
        

        while (!done)
        {
            float delta = constants.moveCurve.Evaluate(time / constants.moveCameraTime);
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, target, delta * constants.moveCameraSpeed);

            if ((camera.transform.position - target).magnitude <= 0.05f)
            {
                camera.transform.position = position;
                done = true;
            }

            time = Mathf.Min(constants.moveCameraTime, time + Time.deltaTime);


            yield return null;
        }

        
       // print("MoveCameraCoroutine stopped");

    }

}
