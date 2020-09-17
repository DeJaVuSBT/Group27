using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
{
    public int level;
    public int percentageTrashCollected;
    private trashUIScript trash;
    private playerManager pl;
    public GameObject LoseScreenCanvas;
    private bool hasEntered = false;
    private void Start()
    {
        hasEntered = false;
    }

    void awake()
    {
        trash = GameObject.FindGameObjectWithTag("TrashUI").GetComponent<trashUIScript>();
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<playerManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"&& !hasEntered)
        {
            
            LoadNextLevel();
            hasEntered = true;
        }
    }

    private void LoadNextLevel()
    {
        if (pl.score > percentageTrashCollected * trash.gos.Length / 100)
        {
            level++;
            LoadFirstLevel();
            LoadSecondLevel();
            LoadThirdLevel();
            LoadVictoryLevel();
        }
        else
        {
            Instantiate(LoseScreenCanvas);
            pl.verticalSpeed = 0f;
        }
    }

    public void LoadFirstLevel()
    {
        if (level == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level1");
        }
    }

    public void LoadSecondLevel()
    {
        if (level == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level2");
        }
    }

    public void LoadThirdLevel()
    {
        if (level == 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level3");
        }
    }

    public void LoadVictoryLevel()
    {
        if (level == 4)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("gameWon");
        }
    }
}
