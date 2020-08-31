using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchObstacle : MonoBehaviour
{
    //This class contains the behaviour for the arches obstacles
    //The arch obstacle rotates around the floor and the player must pass through it when it finds space

    public float speed = 15f;

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime, Space.World);
    }
}
