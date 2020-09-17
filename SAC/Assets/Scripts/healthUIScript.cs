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

    private gameMaster gm;

    private bool hasEntered = false;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        health = gm.lastHealth;
    }

    private void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        if(health == 0)
        {
            GameOver();
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
