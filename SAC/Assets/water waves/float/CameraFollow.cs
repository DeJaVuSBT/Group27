using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Character;
    private gameMaster gm;
    public Vector3 Offset;
    [Range(0.01f, 1.0f)]
    public float Smooth = 0.1f;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        transform.position = gm.lastCameraPos;
        Offset = transform.position - Character.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 Pos = Character.position + Offset;
        transform.position = Vector3.Slerp(transform.position, Pos,Smooth);
    }
}
