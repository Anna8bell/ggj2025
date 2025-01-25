using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened = true;
    public Sprite openedSprite;
    public Sprite closedSprite;

    public SoundController soundController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundController = GameObject.FindGameObjectWithTag("Manager").GetComponent<SoundController>();
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
            soundController.PlayDoorSound();
        }
    }
}
