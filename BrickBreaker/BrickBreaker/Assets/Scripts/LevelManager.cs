using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    SceneLoader sceneLoader;
    [SerializeField] int numBlocks;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlockCreated()
    {
        numBlocks++;
    }

    public void BlockDestroyed()
    {
        numBlocks--;

        if (numBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }


}
