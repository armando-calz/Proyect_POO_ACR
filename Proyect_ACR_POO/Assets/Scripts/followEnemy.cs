using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(target.position, transform.position);
        //Debug.Log(distancia);
        if (distancia < minDistance)
        {
            speed = 3;
           
            anim.SetBool("run", true);
        }

        if (distancia < maxDistance)
        {
            //Debug.Log("Ataque");
            speed = 0;
           
            anim.SetBool("run", false);
            anim.SetTrigger("attack");
        }

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
