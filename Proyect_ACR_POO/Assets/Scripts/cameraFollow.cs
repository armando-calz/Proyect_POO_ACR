using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    Transform Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("camara").transform;
    }


    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = Player.position.x;
        temp.y = Player.position.y+1;
        transform.position = temp;
    }
}
