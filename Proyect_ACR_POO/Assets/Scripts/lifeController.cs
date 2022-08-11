using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeController : HeroKnight, DamageInt, increaseLInt
{
    public int vida = 100;
    public Text vidaText;
    public SpriteRenderer sprite;
    
    public void damage(int daño)
    {
        vida -= daño;
        if (vida <= 0)
            vida = 0;
    }
    public void increaseLife(int increment)
    {
        vida += increment;
    }

    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

}
