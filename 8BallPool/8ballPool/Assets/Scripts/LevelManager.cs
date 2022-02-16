using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    SceneLoader sceneLoader;
    [SerializeField] int numBalls;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallCreated()
    {
        numBalls++;
    }

    public void BallInPocket()
    {
        numBalls--;

        if (numBalls <= 0)
        {
            sceneLoader.ReloadScene();
        }
    }
}
