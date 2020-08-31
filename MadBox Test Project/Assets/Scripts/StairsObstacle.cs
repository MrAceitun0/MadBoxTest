using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsObstacle : MonoBehaviour
{
    //This class contains the behaviour of the stairs gloves obstacle

    public float minPosition;
    public float maxPosition;
    public float moveSpeed;
    public float waitTime;

    public float rotSpeed;

    void Start()
    {
        StartCoroutine(Move());
    }

    private void Update() 
    {
        transform.Rotate(Vector3.right * Time.deltaTime * rotSpeed);    
    }

    IEnumerator Move() //Move the obstacle during the whole scene between two values for z
    {
        while (true)
        {
            while (maxPosition > transform.position.z)
            {
                transform.position += new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed;
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);

            while (minPosition <= transform.position.z)
            {
                transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed;
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
}
