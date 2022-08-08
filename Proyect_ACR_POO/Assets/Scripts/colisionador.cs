using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionador : lifeController
{
    void OnCollisionEnter2D(Collision2D other)
    {
        AsignarEtiqueta("skeleton", other, 15);
    }

    //El metodo funciona para poder contener operaciones con un colisionador
    void AsignarEtiqueta(string etiqueta, Collision2D other, int daño)
    {
        if (other.gameObject.tag == etiqueta)
        {
                damage(daño);
                Debug.Log(vida);
            
            //if (atacking)
            //{
            //    Destroy(other.gameObject);
            //    Debug.Log("DESTRUIR");
            //}
        }
    }
}
