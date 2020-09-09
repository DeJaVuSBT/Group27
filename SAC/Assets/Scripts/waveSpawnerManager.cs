using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawnerManager : MonoBehaviour
{
    //Spawn this object
    public GameObject spawnObject;

    private barrierSpawnerManager barrier;
    private Quaternion rot;

    public float maxTime = 50;
    public float minTime = 1;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    void Start()
    {
        SetRandomTime();
        time = minTime;
        rot = Quaternion.Euler(0, 180, 0);

    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }

    }


    //Spawns the object and resets the time
    void SpawnObject()
    {
        time = minTime;
        //if (transform.position.x < Barrier.barrierLimit)
        //{
            Instantiate(spawnObject, transform.position, spawnObject.transform.rotation);
        //}
        
        //if(transform.position.x > Barrier.barrierLimit)
        //{
        //    Instantiate(spawnObject, transform.position, rot);
        //}
        
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

}