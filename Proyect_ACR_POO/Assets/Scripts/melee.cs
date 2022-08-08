using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class melee : MonoBehaviour
{

    public int vidaCubo = 100;
    //public TextMeshProUGUI vidaText;
    public Transform origin;
    public float sizeCol;

    public Color colorCol;

    public LayerMask enemyLayer;


    private void Awake()
    {
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
        Collider2D impacto = Physics2D.OverlapCircle(origin.position, sizeCol, enemyLayer);
        if (impacto.tag == "skeleton")
        {
            Debug.Log("le pegaste a un esqueleto");
            Destroy(impacto.gameObject);
        }
    }
   

    void OnDrawGizmos()
    {
        DibujarEsfera(origin, sizeCol, colorCol);

    }

    void DibujarEsfera(Transform origin, float size, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(origin.position, size);
    }
}