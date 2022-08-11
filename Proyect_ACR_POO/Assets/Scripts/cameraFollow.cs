using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Armando Calzada R.
    Programacion Orientada a Objetos 
    Josue Israel Rivas Díaz
    Este script se encarga de que la camara siga al personaje principal 
 */
public class cameraFollow : MonoBehaviour
{
    Transform Player;
    void Start()
    {
        //busca el objeto con tag camara
        Player = GameObject.FindGameObjectWithTag("camara").transform;
    }


    void Update()
    {
        // en el update se va actualizando la posicion de la camara igualando la posicion del personaje en "x" y en "y"
        Vector3 temp = transform.position;
        temp.x = Player.position.x;
        temp.y = Player.position.y+1;
        transform.position = temp;
    }
}
