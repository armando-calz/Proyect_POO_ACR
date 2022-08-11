using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    Armando Calzada R.
    Programacion Orientada a Objetos 
    Josue Israel Rivas Díaz
    Este script es el encargado del control de la vida del personaje principal utiliza intefaces para el incremento o decremento de vida
 */
public class lifeController : HeroKnight, DamageInt, increaseLInt
{
    public int vida = 100;
    public Text vidaText;
    public SpriteRenderer sprite;
    
    //es la funcion de daño, rescribe el valor de vida restando el daño del enemigo correspondiente
    public void damage(int daño)
    {
        vida -= daño;
        if (vida <= 0)
            vida = 0;
    }

    //es la funcion de incremento de vida, en caso de haber más objetos sumadores de vida puede cambiar y reescribir el valor
    public void increaseLife(int increment)
    {
        vida += increment;
    }

    //extrae componentes
    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

}
