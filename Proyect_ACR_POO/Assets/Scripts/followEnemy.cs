using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Armando Calzada R.
    Programacion Orientada a Objetos 
    Josue Israel Rivas Díaz
    Este script funciona para que el enemigo siga al personaje principal cuando apareezca en un rango 
 */
public class followEnemy : MonoBehaviour
{
    public Transform target ;

    public float minDistance;

    public float maxDistance;

    public float speed;

    public int m_facingDirection = 1;

    Animator anim;

    private void Start()
    {
        //extrae el componente animator;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //extrae la distancia para establecer los limites de: rango de persecusion y rango de ataque
        float distancia = Vector3.Distance(target.position, transform.position);
        //Debug.Log(distancia);

        //si el personaje se encuentra en rango de persecusion lo va a segui y va a activar la animacion
        if (distancia < minDistance)
        {
            speed = 3;
           
            anim.SetBool("run", true);
        }

        //si se encuentra en rango de ataque va a activar la animacion correspondiente y dejara de moverse
        if (distancia < maxDistance)
        {
            //Debug.Log("Ataque");
            speed = 0;
           
            anim.SetBool("run", false);
            anim.SetTrigger("attack");
        }

        //estos siguientes if else if solo se encargan del flip del enemigo
        if (distancia < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
        }

        else if (distancia > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    // esta funcion solo dibuja gizmos 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
