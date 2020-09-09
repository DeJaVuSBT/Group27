using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierSpawnerManager : MonoBehaviour
{
    public GameObject spawnObject;

    public float barrierLimit = 30f;

    private float height = 5f;
    private Quaternion rot1, rot2;
    
    void Start()
    {
        rot1 = Quaternion.Euler(0, 0, 90);
        rot2 = Quaternion.Euler(0, 0, -90);
        SpawnObject();
    }

    void Update()
    {
        
    }

    void SpawnObject()
    {

        Instantiate(spawnObject, new Vector3(barrierLimit, height, 0), rot1);
        Instantiate(spawnObject, new Vector3(-barrierLimit, height, 0), rot2);
    }

}
