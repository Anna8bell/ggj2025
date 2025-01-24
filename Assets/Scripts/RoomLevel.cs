using UnityEngine;

public class RoomLevel : MonoBehaviour
{
    public Room room1;
    public Room room2;
    public Room room3;

    public GameObject walls;
    public Door door1;
    public Door door2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void HideWalls()
    {
        if (walls != null)
        {
            walls.SetActive(false);
        }

        if (door1 != null)
        {
            door1.gameObject.SetActive(false);
        }

        if (door2 != null)
        {
            door2.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
