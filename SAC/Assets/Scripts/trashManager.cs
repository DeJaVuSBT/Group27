using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashManager : MonoBehaviour
{
    public Vector3 velocity;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            playerManager.score++;
            Destroy(gameObject);
        }
    }
}
