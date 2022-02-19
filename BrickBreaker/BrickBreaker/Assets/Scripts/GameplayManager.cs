using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] Text scoreText;
    int currentScore = 0;

    private void Awake()
    {
        int instancesCount = FindObjectsOfType<GameplayManager>().Length;
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
        scoreText.text = "Score: " + currentScore.ToString();
        //
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore.ToString();
    }


}
