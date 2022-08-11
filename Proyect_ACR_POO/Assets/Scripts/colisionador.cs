using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colisionador : lifeController
{
    public int bandera = 0;
    public Text winText;
    void OnCollisionEnter2D(Collision2D other)
    {
        AsignarEtiqueta("skeleton", other, 10);
        AsignarEtiqueta("goblin", other, 5);
        handicap("pocion", other, 5);
        regreso("back", other);
        pills("pills", other, 10);
        win("win", other);
    }

    //El metodo funciona para poder contener operaciones con un colisionador
    void AsignarEtiqueta(string etiqueta, Collision2D other, int daño)
    {
        if (other.gameObject.tag == etiqueta)
        {
            m_animator.SetTrigger("Hurt");
            damage(daño);
            Debug.Log(vida);
            vidaText.text = "vida: " + vida.ToString();
            if (vida <= 0)
            {
                m_animator.SetTrigger("Death");
                this.gameObject.SetActive(false);
            }
        }
    }
    void handicap(string etiqueta, Collision2D other, int daño)
    {
        if (other.gameObject.tag == etiqueta)
        {
            m_animator.SetTrigger("Hurt");
            m_animator.SetTrigger("Hurt");
            damage(daño);
            Debug.Log(vida);
            vidaText.text = "vida: " + vida.ToString();
            if (vida <= 0)
            {
                m_animator.SetTrigger("Death");
                this.gameObject.SetActive(false);
            }
            if (bandera== 0)
            {
                GetComponent<Transform>().position = new Vector3(-1, -41, 0);
                bandera++;
            }
            else if (bandera== 1)
            {
                GetComponent<Transform>().position = new Vector3(-1, -73, 0);
            }
            Destroy(other.gameObject);
        }
    }
    void regreso(string etiqueta, Collision2D other) 
    {
            if (other.gameObject.tag == etiqueta)
            {
            GetComponent<Transform>().position = new Vector3(57, -20, 0);
            }
     }
    void pills(string etiqueta, Collision2D other, int sumaVida) 
    {
        if (other.gameObject.tag == etiqueta) 
        { 
            increaseLife(sumaVida);
            vidaText.text = "vida: " + vida.ToString();
            Debug.Log("sumó vida");
            Destroy(other.gameObject);
        }
    }
    void win (string etiqueta, Collision2D other)
    {
        if (other.gameObject.tag == etiqueta)
        {
            GetComponent<Transform>().position = new Vector3(0, 0, 0);
            winText.text = "Ganaste!!";
        }
    }

    public void start()
    {
        winText.text = "";
        vidaText.text = "vida: " + vida.ToString();
    }
        
}
