using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour
{
    private static gameMaster instance;
    public Vector3 lastCheckPointPos;
    public Vector3 initialPos;
    public int lastHealth;
    public int lastScore;

    private void Awake()
    {
        initialPos = transform.position;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
