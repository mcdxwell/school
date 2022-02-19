using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    [SerializeField] Text livesText;
    int currentLives = 3;

    private void Awake()
    {
        int instancesCount = FindObjectsOfType<LivesManager>().Length;
        if (instancesCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + currentLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SubToScore(int lives)
    {
        currentLives -= lives;
        livesText.text = "Lives: " + currentLives.ToString();
    }
}
