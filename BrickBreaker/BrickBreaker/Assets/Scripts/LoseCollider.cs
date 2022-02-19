using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    int livesCounter = 3;
    Ball ball;

    private void Awake()
    {
    ball = GameObject.Find("ball").GetComponent<Ball>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LivesManager>().SubToScore(1);
        ball.hasFired = false;
        livesCounter--;
        if (livesCounter < 1)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(sceneName: "Game Over");
            
            

        }

    }
}
