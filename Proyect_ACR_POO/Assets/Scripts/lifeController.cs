using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeController : HeroKnight, DamageInt, increaseLInt
{
    public int vida = 100;
    
    public void damage(int daño)
    {
        vida -= daño;
    }
    public void increaseLife(int increment)
    {
        vida += increment;
    }

    public void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void Update()
    {
       
    }
}
