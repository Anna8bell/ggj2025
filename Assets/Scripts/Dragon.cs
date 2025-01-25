using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ThrowFire()
    {
        animator.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
