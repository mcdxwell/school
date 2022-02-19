using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float minX = -9f;
    float maxX = 9f;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.hasFired)
        {
            float newX = ((Input.mousePosition.x / Screen.width) - 0.5f) * (maxX - minX);
            if ((newX > minX) && (newX < maxX))
            {
                Vector2 newPaddlePos = new Vector2(newX, transform.position.y);
                transform.position = newPaddlePos;
            }
        }
    }
}
