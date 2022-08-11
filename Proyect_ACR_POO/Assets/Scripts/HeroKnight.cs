using UnityEngine;
using System.Collections;

public class HeroKnight : MonoBehaviour
{

    [SerializeField] float m_speed = 4.0f;
    [SerializeField] float m_jumpForce = 15;
    [SerializeField] float m_rollForce = 6.0f;
    [SerializeField] bool m_noBlood = false;
    [SerializeField] GameObject m_slideDust;

    public Animator m_animator;
    public Rigidbody2D m_body2d;
    public Sensor_HeroKnight m_groundSensor;
    public Sensor_HeroKnight m_wallSensorR1;
    public Sensor_HeroKnight m_wallSensorR2;
    public Sensor_HeroKnight m_wallSensorL1;
    public Sensor_HeroKnight m_wallSensorL2;
    public bool m_isWallSliding = false;
    public bool doubleJump = false;
    public bool m_grounded = false;
    public bool m_rolling = false;
    public bool atacking = false;
    public int m_facingDirection = 1;
    public int m_currentAttack = 0;
    public float m_timeSinceAttack = 0.0f;
    public float m_delayToIdle = 0.0f;
    public float m_rollDuration = 8.0f / 14.0f;
    public float m_rollCurrentTime;


    // inicializa y trae valores del objeto
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_HeroKnight>();
        m_wallSensorR1 = transform.Find("WallSensor_R1").GetComponent<Sensor_HeroKnight>();
        m_wallSensorR2 = transform.Find("WallSensor_R2").GetComponent<Sensor_HeroKnight>();
        m_wallSensorL1 = transform.Find("WallSensor_L1").GetComponent<Sensor_HeroKnight>();
        m_wallSensorL2 = transform.Find("WallSensor_L2").GetComponent<Sensor_HeroKnight>();
    }

    // Update is called once per frame
    void Update()
    {
        atacking = false;
        // funciona para saber si puede realizar un doble salto
        if (!m_isWallSliding)
        {
            doubleJump = false;
        }

        //aumenta el contador para el tiempo de ataque 
        m_timeSinceAttack += Time.deltaTime;

        //aumenta el contador para el tiempo de roll
        if (m_rolling)
            m_rollCurrentTime += Time.deltaTime;

        //deshabilita el roll si pasa el tiempo
        if (m_rollCurrentTime > m_rollDuration)
            m_rolling = false;

        //detecta con un sensor si se encuentra pisando el suelo
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //detecta si el jugador está callendo
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //funciona para realizar los flip del personaje
        float inputX = Input.GetAxis("Horizontal");

        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
        }

        else if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
        }

        // Move
        // controla el movimiento del personaje (si no se encuentra girando)
        if (!m_rolling)
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);


        m_animator.SetFloat("AirSpeedY", m_body2d.velocity.y);

        //Wall Slide
        //controla el estado del slide del personaje con los sensores y tambien controla la animacion
        m_isWallSliding = (m_wallSensorR1.State() && m_wallSensorR2.State()) || (m_wallSensorL1.State() && m_wallSensorL2.State());
        m_animator.SetBool("WallSlide", m_isWallSliding);

        //Death
        //esto funciona para probar la animacion de muerte
        if (Input.GetKeyDown("e") && !m_rolling)
        {
            m_animator.SetBool("Blood", m_noBlood);
            m_animator.SetTrigger("Death");
        }

        //Hurt
        //esto funciona para probar la animacion de daño
        else if (Input.GetKeyDown("q") && !m_rolling)
            m_animator.SetTrigger("Hurt");

        //Attack
        else if (Input.GetMouseButtonDown(0) && m_timeSinceAttack > 0.25f && !m_rolling)
        {
            atacking = true;
            m_currentAttack++;

            // controla el indice del ataque para saber que animacion hacer
            if (m_currentAttack > 3)
                m_currentAttack = 1;

            // resetea la secuencia de ataques si el tiempo entre los ataques fue mucho
            if (m_timeSinceAttack > 1.0f)
                m_currentAttack = 1;

            // llama a una de las animaciones de ataque de la secuencia
            m_animator.SetTrigger("Attack" + m_currentAttack);

            // reiniciar contador de ataque 
            m_timeSinceAttack = 0.0f;
        }

        // Block
        // controla la animacion de bloqueo del personaje. si está girando no hace la animacion 
        else if (Input.GetMouseButtonDown(1) && !m_rolling)
        {
            m_animator.SetTrigger("Block");
            m_animator.SetBool("IdleBlock", true);
        }

        else if (Input.GetMouseButtonUp(1))
            m_animator.SetBool("IdleBlock", false);

        // Roll
        // controla la animacion de roll, si está girando o deslizandose no hace la animacion
        else if (Input.GetKeyDown("left shift") && !m_rolling && !m_isWallSliding)
        {
            m_rolling = true;
            m_animator.SetTrigger("Roll");
            m_body2d.velocity = new Vector2(m_facingDirection * m_rollForce, m_body2d.velocity.y);
        }


        //Jump
        // controla el salto del personaje 
        else if (Input.GetKeyDown("space"))
        {
            // si esta en el piso y no está girando hace el salto
            if (m_grounded && !m_rolling)
            {
                m_animator.SetTrigger("Jump");
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
                m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
                m_groundSensor.Disable(0.2f);
            }
            // si está deslizandose y no ha hecho un doble salto
            else if (m_isWallSliding && !doubleJump)
            {
                doubleJump = true;
                m_animator.SetTrigger("WallSlide");
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
                m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
                m_groundSensor.Disable(0.2f);
            }
        }
        

        //Run
        // controla las animaciones de correr respecto al movimiento
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            // reinicia el temporizador
            m_delayToIdle = 0.05f;
            m_animator.SetInteger("AnimState", 1);
        }

        //Idle
        else
        {
            // evita problemas al trancisionar a idle
            m_delayToIdle -= Time.deltaTime;
            if (m_delayToIdle < 0)
            m_animator.SetInteger("AnimState", 0);
        }
    }

    // esta funcion solo crea el efecto dust del deslizamiento dependiendo de hacia donde esté viendo
    void AE_SlideDust()
    {
        Vector3 spawnPosition;

        if (m_facingDirection == 1)
            spawnPosition = m_wallSensorR2.transform.position;
        else
            spawnPosition = m_wallSensorL2.transform.position;

        if (m_slideDust != null)
        {
            GameObject dust = Instantiate(m_slideDust, spawnPosition, gameObject.transform.localRotation) as GameObject;
            dust.transform.localScale = new Vector3(m_facingDirection, 1, 1);
        }
    }
}
