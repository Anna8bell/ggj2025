using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUPrefixSum;

public class FireWall : MonoBehaviour
{
    //public List<GameObject> fires = new List<GameObject>();
    public GameObject firePrefab;
    private Vector3 left = new Vector3(0,0,0);
    private Vector3 right = new Vector3(0,0,0);
    public MoveController moveController;

    public void StartFire()
    {
        StartCoroutine(IgnitionCoroutine());
    }

    private IEnumerator IgnitionCoroutine()
    {
        moveController.tasks.AddLast(gameObject);
        yield return new WaitForSeconds(0.5f);

        var fire = Instantiate(firePrefab, left, Quaternion.Euler(0, 0, 0), transform);
        fire.transform.localPosition = left;


        for (int i = 0; i < 13; i++)
        {
            {
                yield return new WaitForSeconds(0.1f);

                left -= new Vector3(1, 0, 0);
                right += new Vector3(1, 0, 0);

                fire = Instantiate(firePrefab, left, Quaternion.Euler(0, 0, 0), transform);
                fire.transform.localPosition = left;
                fire = Instantiate(firePrefab, right, Quaternion.Euler(0, 0, 0), transform);
                fire.transform.localPosition = right;
            }
        }
        moveController.tasks.Remove(gameObject);
    }

    public void StepDown()
    {
        transform.position -= new Vector3(0,1.2f,0);
    }
}
