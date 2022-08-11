using UnityEngine;
using System.Collections;
/*
    Armando Calzada R.
    Programacion Orientada a Objetos 
    Josue Israel Rivas Díaz
    Este script se asigna a cada sensor para que por medio de su estado retorne valores y se puedan utilizar para la lógica en el script heroKnight
 */
public class Sensor_HeroKnight : MonoBehaviour {

    private int m_ColCount = 0;

    private float m_DisableTimer;

    private void OnEnable()
    {
        m_ColCount = 0;
    }

    public bool State()
    {
        if (m_DisableTimer > 0)
            return false;
        return m_ColCount > 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        m_ColCount++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        m_ColCount--;
    }

    void Update()
    {
        m_DisableTimer -= Time.deltaTime;
    }

    public void Disable(float duration)
    {
        m_DisableTimer = duration;
    }
}
