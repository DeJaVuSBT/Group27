using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
{
    public int level;
    public int percentageTrashCollected;
    private trashUIScript trash;
    private playerManager pl;
    public GameObject LoseScreenCanvas1;
    public GameObject LoseScreenCanvas2;
    public GameObject LoseScreenCanvas3;
    public GameObject GameWonScreen1;
    public GameObject GameWonScreen2;
    public GameObject GameWonScreen3;

    private bool hasEntered = false;
    private void Start()
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
            if(level == 1)
            {
                Instantiate(GameWonScreen1);
            }

            if (level == 2)
            {
                Instantiate(GameWonScreen2);
            }

            if (level == 3)
            {
                Instantiate(GameWonScreen3);
            }
        }
        else
        {
            if (level == 1)
            {
                Instantiate(LoseScreenCanvas1);
            }

            if (level == 2)
            {
                Instantiate(LoseScreenCanvas2);
            }

            if (level == 3)
            {
                Instantiate(LoseScreenCanvas3);
            }
            pl.verticalSpeed = 0f;
        }
    }

}
