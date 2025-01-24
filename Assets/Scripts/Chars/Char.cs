using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Char : MonoBehaviour
{
    public Room currentRoom;
    public Constants constants;

    private MoveController moveController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var managerObject = GameObject.FindGameObjectWithTag("Manager");
        moveController = managerObject.GetComponent<MoveController>();
        constants = managerObject.GetComponent<Constants>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToSideRoom(Room room)
    {
        StartCoroutine(MoveCoroutine(room));
       
    }

    public void MoveDown(Room room)
    {
        StartCoroutine(MoveDownCoroutine(room));
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

    private IEnumerator MoveCoroutine(Room room)
    {
        print("MoveCoroutine started");

        float time = 0;
        var target = room.mainSlot.transform.position;
        moveController.tasks.AddLast(gameObject);

        while (currentRoom != room)
        {
            float delta = constants.moveCurve.Evaluate(time/ constants.moveTime);
            transform.position = Vector3.MoveTowards(transform.position, target, delta * constants.moveSpeed);

            if ((transform.position - target).magnitude <= 0.1f )
            {
                currentRoom = room;
            }

            time = Mathf.Min(constants.moveTime, time + Time.deltaTime);
           

            yield return null;
        }

        moveController.tasks.Remove(gameObject);
        print("MoveCoroutine stopped");

    }

    private IEnumerator MoveDownCoroutine(Room room)
    {
        print("MoveDownCoroutine started");

        float time = 0;
        var target = room.mainSlot.transform.position;
        moveController.tasks.AddLast(gameObject);

        while (currentRoom != room)
        {
            float delta = constants.moveCurve.Evaluate(time / constants.moveDownTime);
            transform.position = Vector3.MoveTowards(transform.position, target, delta * constants.moveDownSpeed);

            if ((transform.position - target).magnitude <= 0.1f)
            {
                currentRoom = room;
            }

            time = Mathf.Min(constants.moveDownTime, time + Time.deltaTime);


            yield return null;
        }

        moveController.tasks.Remove(gameObject);
        print("MoveDownCoroutine stopped");

    }

}
