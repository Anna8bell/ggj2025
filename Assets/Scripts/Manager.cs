using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Char hero;
    public LevelBuilder levelBuilder;
    public MoveController moveController;
    public UiController uiController;
    public Constants constants;

    public RoomLevel currentLevel;
    public RoomLevel nextLevel;

    public Dragon dragon;
    public FireWall fireWall;

    public Camera camera;

    public Mode mode = Mode.Menu;

    public int coins = 0;
    public int keys = 0;
    public int enemies = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelBuilder = GetComponent<LevelBuilder>();
        moveController = GetComponent<MoveController>();
        uiController = GetComponent<UiController>();
        constants = GetComponent<Constants>();
        currentLevel = levelBuilder.GenerateStartLevel();
        nextLevel = levelBuilder.GenerateLevel(true);

        hero.gameObject.transform.position = currentLevel.room1.combatSlot1.transform.position;
        hero.currentRoom = currentLevel.room1;
        hero.currentRoom.DefaultItemSelection();

       // dragon.gameObject.transform.position = currentLevel.room3.mainSlot.transform.position;

        uiController.ShowMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == Mode.GameOver) 
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return;
        }

        if (mode == Mode.Menu)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                mode = Mode.Cutscene;
                StartCoroutine(StartCutsceneCoroutine());
                
            }
            return;
        }

        if (!moveController.CanDoNextMove()) 
            return;

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            if (hero.CanGoRight())
            {
                hero.MoveToSideRoom(hero.currentRoom.right, true);
                fireWall.StepDown();
            }
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            if (hero.CanGoLeft())
            {
                hero.MoveToSideRoom(hero.currentRoom.left, false);
                fireWall.StepDown();
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
            fireWall.StepDown();

            SwitchLevel();
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var enemy = hero.CanFight();
            if (enemy != null)
            {
                hero.Fight(enemy, true);
                enemy.Fight(enemy, false);
                fireWall.StepDown();
            }
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            var selectedSlot = hero.currentRoom.selectedItemSlot;
            
            if (selectedSlot != null && selectedSlot.item != null)
            {
                selectedSlot.item.DoAction(hero, this);
                fireWall.StepDown();
            }
        }
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            hero.currentRoom.SelectLeftItem();
        }
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            hero.currentRoom.SelectRightItem();
        }

        if (hero.transform.position.y + 2.6f > fireWall.transform.position.y)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        mode = Mode.GameOver;
        hero.HideDeadHero();
        uiController.ShowGameOver();
    }

    private void SwitchLevel()
    {
        currentLevel = nextLevel;
        nextLevel = levelBuilder.GenerateLevel(true);

        StartCoroutine(MoveCameraCoroutine(new Vector3(camera.transform.position.x, currentLevel.transform.position.y - 6, camera.transform.position.z)));
    }

    public void RemoveCollectedItem()
    {
        hero.currentRoom.selectedItemSlot.item = null;
        hero.currentRoom.DefaultItemSelection();
    }

    public void MinusKey()
    {
        if (keys > 0)
        {
            keys--;
            uiController.SetKeysText(keys);
        }

    }

    public void MinusCoin()
    {
        if (coins > 0)
        {
            coins--;
            uiController.SetCoinsText(coins);
        }

    }

    public void MinusEnemy()
    {
        if (enemies == 0)
        {
            // TODO you won
        }
        else
        {
            enemies--;
            uiController.SetEnemiesText(enemies);
        }


    }

    private IEnumerator StartCutsceneCoroutine()
    {
        dragon.ThrowFire();
        fireWall.StartFire();

        yield return new WaitForSeconds(2);

        uiController.ShowGameplay();
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

    public enum Mode
    {
        Menu,
        Gameplay,
        Cutscene,
        GameOver
    }

}
