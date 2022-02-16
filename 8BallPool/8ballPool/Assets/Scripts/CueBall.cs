using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{
    Vector2 orginalPos;
    public Rigidbody2D cueBallRB;
    // Start is called before the first frame update
    void Start()
    {
        orginalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y); // original position of cueball
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.transform.position = orginalPos; // move cueball to original position when triggered by pocket
        cueBallRB.velocity = new Vector2(0f, 0f); // this makes it so that the ball does not go into a pocket infinitely
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Cue Ball has made contact with Cue or pocket.");
    }
}
