using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] AudioClip breakSound;
    [SerializeField] int numHits;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] breakSprites;


    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.BlockCreated();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameplayManager>().AddToScore(1);

        numHits++;
        if (numHits >= maxHits)
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            Destroy(gameObject);
            levelManager.BlockDestroyed();
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = breakSprites[numHits - 1];
        }

    }

}
