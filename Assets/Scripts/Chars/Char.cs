using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public Room currentRoom;
    public Constants constants;

    public SpriteRenderer armorRenderer;
    public SpriteRenderer shieldRenderer;
    public SpriteRenderer swordRenderer;
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer hairRenderer;

    public List<Equip> equips = new List<Equip>(); 

    private MoveController moveController;
    private Manager manager;
    private System.Random random = new System.Random();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var managerObject = GameObject.FindGameObjectWithTag("Manager");
        moveController = managerObject.GetComponent<MoveController>();
        constants = managerObject.GetComponent<Constants>();
        manager = managerObject.GetComponent<Manager>();

        if (shieldRenderer != null) 
        {
            shieldRenderer.enabled = false;
        }
        if (armorRenderer != null)
        {
            armorRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToSideRoom(Room room, bool toRight)
    {
        StartCoroutine(MoveCoroutine(room, toRight));
       
    }

    public void MoveDown(Room room)
    {
        StartCoroutine(MoveDownCoroutine(room));
    }

    public void HideDeadHero()
    {
        bodyRenderer.enabled = false;
        armorRenderer.enabled = false;
        swordRenderer.enabled = false;
        shieldRenderer.enabled=false;
        hairRenderer.enabled=false;

    }

    public void OnHit(bool isHero)
    {
        if (equips.Count == 0)
        {
            //TODO dead
            if (!isHero)
            {
                manager.hero.currentRoom.combatSlot2.character = null;
                Destroy(gameObject);
                manager.MinusEnemy();
            } else
            {
                manager.GameOver();
               
            }

            return;
        }

        var dropItemIndex = random.Next(equips.Count);

        var dropEquip = equips[dropItemIndex];
        equips.Remove(dropEquip);

        switch (dropEquip)
        {
            case Equip.Armor:
                StartCoroutine(DropEquipCoroutine(armorRenderer, isHero));
                break;
            case Equip.Shield:
                StartCoroutine(DropEquipCoroutine(shieldRenderer, isHero));
                break;
        }
        //TODO spawn lost item
    }

    private IEnumerator DropEquipCoroutine(SpriteRenderer renderer, bool isHero)
    {
        // print("MoveCoroutine started");

        float time = 0;
        var prevPosition = renderer.transform.position;
        var target = renderer.transform.position;
        if (isHero)
        {
            target -= new Vector3(2f, 0, 0);
        }
        else
        {
            target += new Vector3(2f, 0, 0);
        }

        while (target != renderer.transform.position)
        {
            float delta = constants.moveCurve.Evaluate(time / constants.dropEquipTime);
            renderer.transform.position = Vector3.MoveTowards(transform.position, target, delta * constants.dropEquipSpeed);

            if ((renderer.transform.position - target).magnitude <= 0.1f)
            {
                renderer.transform.position = target;
            }

            time = Mathf.Min(constants.dropEquipTime, time + Time.deltaTime);

            yield return null;
        }

        renderer.enabled = false;
        renderer.transform.position = prevPosition;

    }

    public void OnEquipFound(Equip equip)
    {
        switch (equip)
        {
            case Equip.Armor:
                armorRenderer.transform.position = transform.position;
                armorRenderer.enabled = true;
                break;
            case Equip.Shield:
                shieldRenderer.transform.position = transform.position;
                shieldRenderer.enabled = true;
                break;
        }

        equips.Add(equip);
    }

    public bool CanGoRight()
    {
        if (currentRoom.right == null) return false;

        var door = currentRoom.rightDoor;

        if (!door.gameObject.activeSelf) return true;


        if (door.isOpened)
        {
            return true;
        }
        else
        {
            if (manager.keys > 0)
            {
                manager.MinusKey();
                door.Open();
            }
            return false;
        }
    }

    public bool CanGoLeft()
    {
        if (currentRoom.left == null) return false;

        var door = currentRoom.leftDoor;

        if (!door.gameObject.activeSelf) return true;


        if (door.isOpened)
        {
            return true;
        }
        else
        {
            if (manager.keys > 0)
            {
                manager.MinusKey();
                door.Open();
            }
            return false;
        }
    }

    public Char CanFight()
    {
        return currentRoom.combatSlot2.character; 
        
    }

    public void Fight(Char enemy, bool isHero)
    {
        StartCoroutine(FightCoroutine(enemy,isHero));
    }

    private IEnumerator FightCoroutine(Char enemy, bool isHero)
    {
        // print("MoveCoroutine started");

        float time = 0;
        var prevPosition = transform.position;
        var targetHero = transform.position;
        if (isHero)
        {
            targetHero += new Vector3(0.5f, 0, 0);
            moveController.tasks.AddLast(gameObject);
        }
        else
        {
            targetHero -= new Vector3(0.5f, 0, 0);
        }
        

        while (targetHero != transform.position)
        {
            float delta = constants.moveCurve.Evaluate(time / constants.moveTime);
            transform.position = Vector3.MoveTowards(transform.position, targetHero, delta * constants.attackSpeed);

            if ((transform.position - targetHero).magnitude <= 0.1f)
            {
                transform.position = targetHero;
            }

            time = Mathf.Min(constants.moveTime, time + Time.deltaTime);

            yield return null;
        }

        OnHit(isHero);

        while (prevPosition != transform.position)
        {
            float delta = constants.moveCurve.Evaluate(time / constants.moveTime);
            transform.position = Vector3.MoveTowards(transform.position, prevPosition, delta * constants.attackSpeed);

            if ((transform.position - prevPosition).magnitude <= 0.1f)
            {
                transform.position = prevPosition;
            }

            time = Mathf.Min(constants.moveTime, time + Time.deltaTime);

            yield return null;
        }

        if (isHero)
        {
            moveController.tasks.Remove(gameObject);
        }
        // print("MoveCoroutine stopped");

    }

    private IEnumerator MoveCoroutine(Room room, bool toRight)
    {
       // print("MoveCoroutine started");

        float time = 0;
        var target = room.combatSlot1.transform.position;
        moveController.tasks.AddLast(gameObject);

        if (toRight) {
            transform.localScale = new Vector3(1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

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

        transform.localScale = new Vector3(1, 1, 1);
        currentRoom.DefaultItemSelection();
        moveController.tasks.Remove(gameObject);
       // print("MoveCoroutine stopped");

    }

    private IEnumerator MoveDownCoroutine(Room room)
    {
        //print("MoveDownCoroutine started");

        float time = 0;
        var target = room.combatSlot1.transform.position;
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

        currentRoom.DefaultItemSelection();
        moveController.tasks.Remove(gameObject);
        //print("MoveDownCoroutine stopped");

    }

    public enum Equip
    {
        Armor, Shield
    }

}
