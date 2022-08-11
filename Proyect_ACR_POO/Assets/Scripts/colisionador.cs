using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    Armando Calzada R.
    Programacion Orientada a Objetos 
    Josue Israel Rivas Díaz
    Este script se encarga de detectar las colisiones y realizar las acciones correspondientes
 */
public class colisionador : lifeController
{
    public int bandera = 0;
    public Text winText;

    //cuando se detecte la colision va a invocar y comparar las etiquetas, pueden afectar la vida, el componente transform, el sprite renderer
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
                GetComponent<Transform>().position = new Vector3(0, 0, 0);
                this.transform.gameObject.SetActive(false);
                winText.text = "Perdiste";
            }
        }
    }

    //funcion cunado colisiona con la pocion morada que afecta el componente transform y la vida
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
                this.transform.gameObject.SetActive(false);
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
    //funcion  cuando colisiona con la pocion vacia que afecta el componente transform y lo regresa al mapa 
    void regreso(string etiqueta, Collision2D other) 
    {
            if (other.gameObject.tag == etiqueta)
            {
            GetComponent<Transform>().position = new Vector3(57, -20, 0);
            }
     }
    //funcion cuando colisiona con  las pildoras que le suman cierta vida
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
    //funcion para cuando colisiona con el trebol afecta la posicion 
    void win (string etiqueta, Collision2D other)
    {
        if (other.gameObject.tag == etiqueta)
        {
            GetComponent<Transform>().position = new Vector3(0, 0, 0);
            winText.text = "Ganaste!!";
        }
    }

    //solo rescribe los valores de interfaz de usuario
    public void start()
    {
        winText.text = "";
        vidaText.text = "vida: " + vida.ToString();
    }
        
}
