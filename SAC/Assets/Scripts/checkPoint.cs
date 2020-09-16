using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private gameMaster gm;
    public CameraFollow camera;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
            gm.lastCheckPointPos = transform.position;
            gm.lastCameraPos = camera.transform.position;
            
        }
    }
}
