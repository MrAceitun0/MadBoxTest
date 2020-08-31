using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    public Transform target; //Next position the player must move to
    public Transform checkpoint; //Last checkpoint where the player will respawn if it fails an obstacle

    private Animator playerAnimator;
    public bool isDead = false;
    public bool isWin = false;
    public bool isStairs = false;

    public CameraController cam;
    bool isEnemy;   //Most of the code works for both player and enemy instead of the camera controller

    public GUIController gui;

    void Start()
    {
        isEnemy = this.CompareTag("Enemy");

        playerAnimator = GetComponent<Animator>();

        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
    }
    
    void Update()
    {
        if (isWin)
            StartCoroutine(ReloadScene(2));

        if (isEnemy && !isDead && !isWin) //AI movement
        {
            /*AI Enemy not finished because lack of time but I'll write the pseudocode for a dummy AI a bit more "realistic"
            than the current one that just moves forward without taking into account the obstacles*/
            /*
             * Approach for the AI:
             * If the script is assigned to an enemy:
             *  1. Raycast forward and only detect if the raycast hits a gameobject tagged as "Obstacle"
             *      if it does not find any obstacle --> move forward
             *      else
             *          --> Compute a random value between 0 and 1
             *          if it is greater than a threshold (let's say 0.5 at the moment) --> move
             *          else --> don't move
             * */
            /* With this approach we will have an AI that detects obstacles but not always will avoid them by stopping a few meters before.
             * We can adjust how good the AI can be just by moving the threshold values for stopping and moving the agent*/

            playerAnimator.SetFloat("Speed_f", 0.26f);

            if (isStairs)
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
            else
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        else if ((Input.GetMouseButton(0) || Input.touchCount > 0) && !isDead && !isWin && !gui.results.enabled) //Player movement for both mouse and touch controls
        {
            gui.instructions.enabled = false;

            playerAnimator.SetFloat("Speed_f", 0.26f);

            if (isStairs) //Movement changes depending if the player is on the ground or climbing stairs
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
            else
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        else
            playerAnimator.SetFloat("Speed_f", 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint")) //Procedure if the player finds a checkpoint
        {
            Checkpoint trigger = other.GetComponent<Checkpoint>();
            if (trigger.isSavePoint) //Save values for respawning, update UI and modify camera position and rotation if needed
            {
                checkpoint = other.transform;
                if (isEnemy)
                {
                    gui.UpdateEnemyStatus(trigger.guiXPosition);
                }
                else
                {
                    gui.UpdatePlayerStatus(trigger.guiXPosition);
                    cam.UpdateOffsets(trigger.cameraPositionOffset, Quaternion.Euler(trigger.cameraRotationOffset));
                }
            }

            if (trigger.nextCheckpoint) //Change direction of player to move towards the next desired position
            {
                transform.LookAt(new Vector3(trigger.nextCheckpoint.position.x, transform.position.y, trigger.nextCheckpoint.position.z));
                target = trigger.nextCheckpoint;
            }

            if(trigger.finalCheckpoint) //Check if the player reaches the final, display UI and move camera
            {
                isWin = true;
                gui.results.enabled = true;

                if (isEnemy)
                {
                    gui.results.text = "You lose!";
                }
                else
                {
                    gui.results.text = "You win!";
                    cam.UpdateOffsets(trigger.cameraPositionOffset, Quaternion.Euler(trigger.cameraRotationOffset));
                }
            }
        }

        if (other.gameObject.CompareTag("Stairs")) //Change gravity depending on the player if it is climbing stairs or on the ground
        {
            isStairs = !isStairs;
            GetComponent<Rigidbody>().useGravity = !isStairs;
        }
    }

    private void OnCollisionEnter(Collision collision) //Animation and respawning if the player collides against an obstacle
    {
        //It is used OnCollisionEnter because it can be further improved to contain real physics collisions that wouldn't work automatically if OnTriggerEnter was used
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            isDead = true;

            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            StartCoroutine(RestartPlayer());
        }
    }

    IEnumerator RestartPlayer() //Respawning to the last savepoint
    {
        yield return new WaitForSeconds(1.5f);

        playerAnimator.SetBool("Death_b", false);

        target = checkpoint.GetComponent<Checkpoint>().nextCheckpoint;
        transform.position = checkpoint.position;

        transform.LookAt(new Vector3(target.position.x, 0.6f, target.position.z));

        isStairs = false;
        GetComponent<Rigidbody>().useGravity = true;

        isDead = false;
    }

    IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
