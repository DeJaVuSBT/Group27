using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private gameMaster gm;
    private playerManager player;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gm.lastCheckPointPos = transform.position;
            gm.lastScore = player.score;
        }
    }
}
