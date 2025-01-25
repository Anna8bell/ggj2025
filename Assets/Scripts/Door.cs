using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened = true;
    public Sprite openedSprite;
    public Sprite closedSprite;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close()
    {
        isOpened = false;
        GetComponent<SpriteRenderer>().sprite = closedSprite;
    }

    public void Open()
    {
        if (!isOpened)
        {
            isOpened = true;
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
    }
}
