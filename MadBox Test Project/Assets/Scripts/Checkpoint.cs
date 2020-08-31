using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    /*This class contains values needed for
    * 1. Movement of the player
    * 2. Position and rotation for the camera
    * 3. Is that gameobject a respawn/save point or the winning point?
    * 4. Relative position to the obstacles to update the GUI
    */
    public Transform nextCheckpoint;
    public Vector3 cameraPositionOffset;
    public Vector3 cameraRotationOffset;
    public bool isSavePoint;
    public bool finalCheckpoint;
    public Vector3 guiXPosition;
}
