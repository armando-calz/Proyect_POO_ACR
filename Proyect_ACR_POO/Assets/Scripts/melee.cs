using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

/*
    Armando Calzada R.
    Programacion Orientada a Objetos 
    Josue Israel Rivas Díaz
    se encarga del ataque a los enemigos, se asigna a los empty que simulan la espada y se encarga de hacer daño o destruir un objeto
 */
public class melee : MonoBehaviour
{

    public int vidaCubo = 100;
    public Transform origin;
    public float sizeCol;

    public Color colorCol;

    public LayerMask enemyLayer;


    private void Awake()
    {
        // se desactiva el empty al iniciar
        origin.gameObject.SetActive(false);
        //   vidaText.text= "Vida Actual: " + vidaCubo;
    }



    // Update is called once per frame
    void Update()
    {
        Checker2D();
        //  vidaText.text= "Vida Actual: " + vidaCubo;
    }

    void Checker2D()
    {
        //este segmento de codigo compara con que objeto colisionó la espada, esto puede utilizarse para realizar diferentes acciones o sonidos dependiendo los materiales
        Collider2D impacto = Physics2D.OverlapCircle(origin.position, sizeCol, enemyLayer);
        if (impacto.tag == "skeleton")
        {
            Debug.Log("le pegaste a un esqueleto");
            Destroy(impacto.gameObject);
        }
        else if (impacto.tag == "goblin")
        {
            Debug.Log("le pegaste a un goblin");
            Destroy(impacto.gameObject);
        }
    }
   

    void OnDrawGizmos()
    {
        //dibuja un gizmo
        DibujarEsfera(origin, sizeCol, colorCol);

    }

    void DibujarEsfera(Transform origin, float size, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(origin.position, size);
    }
}