using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour
{
    // too tired to go 
    
    public GameObject Cue2;
    public GameObject CueBall;

    public Rigidbody2D rb; // rigidbody2d of Cue
    public Rigidbody2D cueBallRB;
    
    public float respawnTime = 5f;
    Vector2 mousePos;

    Vector3 startPosition;

    float timeBtnHeld = 0.0f;
    int seconds;


    float power;

    float speed = 2f;


    bool moveCue = true;
    bool rotateCue = true;




    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        moveToCueBall();

        startPosition = transform.position;
    }

    private void Awake()
    {
        // Find the GameObject for CueBall
        CueBall CueBall = GameObject.Find("CueBall").GetComponent<CueBall>();

    }
    
    
    void Update()
    {
        // Player's mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

        
        

        if (Input.GetKeyDown("space"))
        {
            // used to have the cue go backwards
            rb.velocity = direction * 1/4;
            Debug.Log("Spacebar was pressed");
            

            // The Cue cannot rotate or move to the cueball
            // This allows the cueball to be hit from desired cue position
            moveCue = false;
            rotateCue = false;
        }
        else if (Input.GetKey("space"))
        {

            timeBtnHeld += Time.deltaTime;
            if(timeBtnHeld > 3f)
            {
                rb.velocity = direction * 0;
            }

            seconds = Mathf.FloorToInt(timeBtnHeld % 60);
            Debug.Log("Time pressed: " + seconds); // or use timeBtnHeld
            Debug.Log("Spacebar is being held");

        }
        else if (Input.GetKeyUp("space"))
        {
            HitCueBall(direction);

            
            Debug.Log("Time pressed: " + seconds);
            Debug.Log("Spacebar was released");
            timeBtnHeld = 0f; // Resets timer for the next hit
                              // moveToCueBall();  // Moves Cue to CueBall
            rotateCue = true; // Allows Cue to rotate around CueBall on its next hit
        }

    }

    void FixedUpdate()
    {
       
        // Allow Cue to rotate around CueBall if true
        if(rotateCue)
        {
            rotateAround();
        }

    }


    // rotate around the cueball
    void rotateAround()
    {
        Vector2 lookDirCueBall = mousePos - cueBallRB.position;
        float angle = Mathf.Atan2(lookDirCueBall.y, lookDirCueBall.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void HitCueBall(Vector2 direction)
    {
        float power = givePower(timeBtnHeld); // Gives power based on how long (spacebar) is pressed
        rb.velocity = -direction * 2 * power;
        Debug.Log("Rb velocity: " + rb.velocity);

    }

    // Give power to cue based on time the space bar is held.
    // 1 power for less than a second
    // 2 power for less than two seconds
    // 3 power for 2 seconds or greater
    public float givePower(float time)
    {
        if (time < 1)
        {
            power = 1;
            Debug.Log("Log 1: Power " + power);
        }

        else if (time < 2)
        {
            power = 2;
            Debug.Log("Log 2: Power " + power);
        }
        else
        {
            power = 3;
            Debug.Log("Log 3: Power " + power);
        }

        return power;
    }

    // 
    void moveToCueBall()
    {
        // Set Cue position to the position of the CueBall
        Cue2.transform.position = CueBall.transform.position;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // set cue as inactive
        // TODO: (When the physics is better) - set cue as active once every ball stops moving (do this in ball scripts)

        // When the Cue Collides with a ball (should be Cue Ball) 
        // Make the Cue disappear
        Cue2.SetActive(false);
        Debug.Log("Cue2 setActive to false");
    }

}



