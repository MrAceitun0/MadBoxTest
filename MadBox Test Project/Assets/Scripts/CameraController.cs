using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //This class controls the main camera of the game that will follow the player with certain offsets for both position and rotation
    //The position and rotation of the camera will depend on the obstacles and how the designer wants the camera view at that moment

    public PlayerController player;

    Vector3 posOffset;
    Quaternion rotOffset;
    
    Vector3 velocity = Vector3.zero;

    private void Start()
    {
        posOffset = new Vector3(0f, 6.465f, -10f);
        rotOffset = Quaternion.Euler(15f, 0f, 0f);
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, 0.1f);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotOffset, Time.deltaTime * 5f);
    }

    public void UpdateOffsets(Vector3 pos, Quaternion rot) 
    {
        posOffset = pos;
        rotOffset = rot;
    }
}
