using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingObstacle : MonoBehaviour
{
    //This class contains the behaviour of the boxing gloves obstacle

    public float maxScale;
    public float minScale;
    public float speed;
    public float waitTime;

    void Start()
    {
        transform.localScale = new Vector3(2, 2, 2);
        StartCoroutine(Scale());
    }

    IEnumerator Scale() //Scale the obstacle during the whole scene between two values for z
    {
        while (true)
        {
            while (maxScale > transform.localScale.z)
            {
                transform.localScale += new Vector3(0, 0, 1) * Time.deltaTime * speed;
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);

            while (minScale <= transform.localScale.z)
            {
                transform.localScale -= new Vector3(0, 0, 1) * Time.deltaTime * speed;
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
}
