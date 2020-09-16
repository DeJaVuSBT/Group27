using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private gameMaster gm;
    private CameraFollow camera;
    private playerManager player;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
            gm.lastCheckPointPos = transform.position;
            gm.lastCameraPos = transform.position + camera.Offset;
            gm.lastScore = player.score;
        }
    }
}
