using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    /*This class controls the display of information of GUI:
    * 1. Instructions and winning information
    * 2. Updating the progress bar in-game that displays the last savepoint each player has passed through
    */

    public Text instructions;
    public Text results;

    public RectTransform playerRef;
    public RectTransform enemyRef;

    public void UpdatePlayerStatus(Vector3 pos)
    {
        playerRef.anchoredPosition = pos;
    }

    public void UpdateEnemyStatus(Vector3 pos)
    {
        enemyRef.anchoredPosition = pos;
    }
}