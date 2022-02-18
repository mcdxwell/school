using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float speed = 5.0f; // bomb fall speed
    private Rigidbody2D rig;
    // Start is called before the first frame update

    void Awake()
    {
    }
    void Start()
    {
        // bomb is given downward vertical velocity
        // vector2(x-axis: 0f, y-axis: -5.0f) 
        
    }


    void Update()
    {
        Bird bird = GameObject.Find("bird_0").GetComponent<Bird>();
        rig = this.GetComponent<Rigidbody2D>();
        if (!bird.shouldStop)
        {
            rig.velocity = new Vector2(-speed, 0);
        }
        DestroyPlane();
    }

    void DestroyPlane()
    {
        if (transform.position.x < -14f)
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed: " + this.gameObject.name);
        }
    }
}
