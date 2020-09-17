using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUIScript : MonoBehaviour
{
    public int health = 3;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private endTrigger trigger;

    public GameObject LoseScreenCanvas1;
    public GameObject LoseScreenCanvas2;
    public GameObject LoseScreenCanvas3;

    private gameMaster gm;
    private bool lost = false;
    private bool hasEntered = false;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        trigger = GameObject.FindGameObjectWithTag("EndTrigger").GetComponent<endTrigger>();
        health = gm.lastHealth;
        lost = false;
    }

    private void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        if(health == 0 && !lost)
        {
            if (trigger.level == 1)
            {
                Instantiate(LoseScreenCanvas1);
            }

            if (trigger.level == 2)
            {
                Instantiate(LoseScreenCanvas2);
            }

            if (trigger.level == 3)
            {
                Instantiate(LoseScreenCanvas3);
            }
            lost = true;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Obstacle" && !hasEntered)
            {
                health--;
                hasEntered = true;
            }
        if(collider.tag == "CheckPoint")
        {
            gm.lastHealth = health;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Obstacle")
        {
            hasEntered = false;
        }
    }

    void GameOver()
    {
        Destroy(gameObject);
    }
}
