using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float xLaunch = 2f;
    [SerializeField] float yLaunch = 10f;
    [SerializeField] float randomBounceVelocityMax = 0.5f;
    public bool hasFired = false;

    // Start is called before the first frame update
    void Start()
    {
    }
    public void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        LoseCollider lose = GameObject.Find("ball").GetComponent<LoseCollider>();
        if(Input.GetKeyDown("space") && (hasFired == false))
        {
            LaunchBall();
            hasFired = true;
        }
    }

    void LaunchBall()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(xLaunch, yLaunch);
        Vector2 pos = transform.position;
        pos.x = 0f;
        pos.y = Random.Range(-3f, 0f);
        GetComponent<Rigidbody2D>().transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityToAdd = new Vector2(
            Random.Range(0f, randomBounceVelocityMax),
            Random.Range(0f, randomBounceVelocityMax));
        GetComponent<Rigidbody2D>().velocity += velocityToAdd;

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);

    }

}
