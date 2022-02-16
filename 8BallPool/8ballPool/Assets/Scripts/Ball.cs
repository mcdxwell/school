using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private void Awake()
    {
        
    }
    public Rigidbody2D ballRB;
    bool ballsMoving;
    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        // counts the number of levelManager objects and counts them with BallCreated function.
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.BallCreated();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destroy ball when it hits pocket
        Destroy(gameObject);
        levelManager.BallInPocket();
    }

    void LateUpdate()
    {
        // this function was going to be used if the physics was better
        // and to respawn the cue when the balls aren't moving
        GameObject[] myBalls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject Ball in myBalls)
        {
            if (Ball.GetComponent<Rigidbody2D>().velocity.magnitude > 0.01f)
            {
                ballsMoving = true;
            }
            Debug.Log("Balls are moving:" + ballsMoving);
            ballsMoving = false;
        }
    }


}
