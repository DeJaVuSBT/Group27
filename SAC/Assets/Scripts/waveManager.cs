using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour
{
    public float waveSpeed = 0.1f;
    private float initialX;
    private Vector3 velocity;
    void Start()
    {
        velocity = new Vector3(waveSpeed, 0, 0);
        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-velocity);
        if(transform.position.x < -initialX)
        {
            Destroy(gameObject);
        }
    }
}
