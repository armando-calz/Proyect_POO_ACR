using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] enemigos;

    public Transform[] spawnpoints;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAll", 0.5f, 7);
    }

    void SpawnAll()
    {
        foreach (var s in spawnpoints)
        {
            int randomSpawn = Random.RandomRange(0, enemigos.Length);
            Instantiate(enemigos[randomSpawn], s.position, Quaternion.identity);
        }
    }
}
