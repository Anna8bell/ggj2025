using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public LinkedList<GameObject> tasks = new LinkedList<GameObject>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public bool CanDoNextMove()
    {
        return tasks.Count == 0;
    }

    // Update is called once per frame
    
}
