using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject plane;
    float timer = 0.0f;
    int speedUp = 0;
    float nextSpeedUp = 0.0f;
    float interval = 30f;
    bool shouldStop = false;
    // Start is called before the first frame update
    //Bird bird = GameObject.Find("bird_0").GetComponent<Bird>();

    // Start is called before the first frame update

    void Start()
    {
        
        StartCoroutine(SpawnPlanes());
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpeedUp)
        {


            // next speed up 
            nextSpeedUp += interval;
            

            if(!shouldStop)
            {
                speedUp += 1;
                Debug.Log("Speed up: " + speedUp);

            }
            
        }
        
    }



    IEnumerator SpawnPlanes()
    {
        Bird bird = GameObject.Find("bird_0").GetComponent<Bird>();
        do
        {
            Vector2 pos = transform.position;
            pos.x = 12.2f;
            pos.y = Random.Range(-5f, 5f); // Plane spawns between -5 and 5 on the y-axis

            GameObject aPlane = Instantiate(plane);
            aPlane.transform.position = pos;
            float initialTime = 4f;
            float TimeBetween = initialTime - speedUp;

            if (TimeBetween < 0.1)
            {
                TimeBetween = 0.5f;
                shouldStop = true;

            }

            yield return new WaitForSeconds(TimeBetween);


        } while (!bird.shouldStop);


    }
}
