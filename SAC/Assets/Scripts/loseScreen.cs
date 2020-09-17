using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseScreen : MonoBehaviour
{
    private gameMaster gm;
    private endTrigger trigger;
    private playerPos check;

    private void Start()
    {
        trigger = GameObject.FindGameObjectWithTag("EndTrigger").GetComponent<endTrigger>();
        check = GameObject.FindGameObjectWithTag("Player").GetComponent<playerPos>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
    }

    private void Update()
    {
        
    }

    public void LoadFirstLevel()
    {
        if (trigger.level == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level1");
            gm.lastCheckPointPos = gm.initialPos;
        }
    }

    public void LoadSecondLevel()
    {
        if (trigger.level == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level2");
            gm.lastCheckPointPos = gm.initialPos;
        }
    }

    public void LoadThirdLevel()
    {
        if (trigger.level == 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level3");
            gm.lastCheckPointPos = gm.initialPos;
        }
    }

    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void LoadFromCheckpoint()
    {
        check.LoadFromLastPoint();
    }
}
