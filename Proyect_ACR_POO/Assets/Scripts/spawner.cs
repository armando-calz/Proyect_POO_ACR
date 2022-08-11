using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Armando Calzada R.
    Programacion Orientada a Objetos 
    Josue Israel Rivas D�az
    Este script se encarga de aparecer a los enemigos aleatoriamente en alg�n spawn aleatoriamente seleccionado
 */
public class spawner : MonoBehaviour
{
    public GameObject[] enemigos;

    public Transform[] spawnpoints;


    // Start is called before the first frame update
    void Start()
    {
        //invoca la funcion de spawn al iniciar el juego
        InvokeRepeating("SpawnAll", 0.5f, 7);
    }

    void SpawnAll()
    {
        //por cada spawn va a aparecer un enemigo aleatorio 
        foreach (var s in spawnpoints)
        {
            int randomSpawn = Random.RandomRange(0, enemigos.Length);
            Instantiate(enemigos[randomSpawn], s.position, Quaternion.identity);
        }
    }
}
