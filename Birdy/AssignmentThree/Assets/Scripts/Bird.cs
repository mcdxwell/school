using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public Animator animator;
    public Text gameOver;
    public bool shouldStop = false;
    Rigidbody2D rb;
    [SerializeField] float velo;
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!shouldStop)
        {
            if (Input.GetKeyDown("space"))
            {

                rb.velocity = Vector2.up * velo;
                animator.SetFloat("Speed", rb.velocity.y);
                // Debug.Log("Bird velo: " + rb.velocity);
                Debug.Log("Space pressed");
                //animator.SetBool("IsFlying", true);
                //animator.Play("BirdAnimation");
            }
            animator.SetFloat("Speed", rb.velocity.y);
            //animator.SetBool("IsFlying", false);
            //Debug.Log("Bird velo: " + rb.velocity);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        shouldStop = true;
        gameOver.text = "Game Over";
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
    }
}
