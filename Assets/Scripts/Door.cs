using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        if (!isOpened)
        {
            isOpened = true;
            //TODO -key
            //Change sprite
        }
    }
}
