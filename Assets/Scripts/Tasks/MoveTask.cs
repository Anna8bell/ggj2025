using UnityEngine;

public class MoveTask : Task
{

    private Char character;
    private Room moveTo;

    public MoveTask(Char character, Room moveTo)
    {
        this.character = character;
        this.moveTo = moveTo;
    }
    public void Do()
    {
        //transform.position = room.mainSlot.transform.position;
    }
}
