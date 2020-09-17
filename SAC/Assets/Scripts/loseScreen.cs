using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseScreen : MonoBehaviour
{
    private endTrigger trigger;
    private playerPos check;

    private void Start()
    {
        trigger = GameObject.FindGameObjectWithTag("EndTrigger").GetComponent<endTrigger>();
        check = GameObject.FindGameObjectWithTag("Player").GetComponent<playerPos>();
    }

    private void Update()
    {
        
    }

    public void LoadFirstLevel()
    {
        if (trigger.level == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level1");
        }
    }

    public void LoadSecondLevel()
    {
        if (trigger.level == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level2");
        }
    }

    public void LoadThirdLevel()
    {
        if (trigger.level == 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level3");
        }
    }

    public void LoadVictoryLevel()
    {
        if (trigger.level == 4)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("gameWon");
        }
    }

    public void LoadFromCheckpoint()
    {
        check.LoadFromLastPoint();
    }
}
