using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceTrianglesRotator : MonoBehaviour
{
    //This class controls the rotation for the triangle above the players
    public float rotSpeed = 15f;

    void Update()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
    }
}
