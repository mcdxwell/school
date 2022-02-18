using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        Bird bird = GameObject.Find("bird_0").GetComponent<Bird>();

        if (!bird.shouldStop)
        {
            offset = moveSpeed * Time.deltaTime;
            material.mainTextureOffset += offset;

        }
    }
}