using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerCadeirante : MonoBehaviour
{
    [Header("Boost")]
    public bool moving;
    public bool boost;
    public GameObject DirecaoBoost;
    private GameObject MovingDirection;

    [Header("Chão")]
    public GameObject LocalPe;
    public bool NoChao;
    public float ChaoTouchVel;
    public float radius;
    public LayerMask CamadaPisavel;

    [Header("Movimentação")]
    public float velocidadeCorrendo;
    public float velocidadeNormal;
    private float eixoX;
    private float aceleracao;
    Rigidbody2D rbPlayerCadeira;

    void Start()
    {
        rbPlayerCadeira = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if (NoChao)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                aceleracao = velocidadeCorrendo * eixoX;
                rbPlayerCadeira.velocity = new Vector2(aceleracao, rbPlayerCadeira.velocity.y);
                rbPlayerCadeira.gravityScale = 1f;
            }
            else
            {
                aceleracao = velocidadeNormal * eixoX;
                rbPlayerCadeira.velocity = new Vector2(aceleracao, rbPlayerCadeira.velocity.y);
                rbPlayerCadeira.gravityScale = 7f;
            }
            if(ChaoTouchVel <= -20)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            ChaoTouchVel = rbPlayerCadeira.velocity.y;
        }

        if (boost && Input.GetKeyDown(KeyCode.UpArrow))
        {
            moving = true;
            MovingDirection = DirecaoBoost;
        }

        if (moving)
        {
            rbPlayerCadeira.gravityScale = 0f;
            transform.position = Vector3.MoveTowards(transform.position, MovingDirection.transform.position, 0.2f);
            if (transform.position == MovingDirection.transform.position)
            {
                moving = false;
                rbPlayerCadeira.gravityScale = 1f;
            }
        }

        NoChao = Physics2D.OverlapCircle(LocalPe.transform.position, radius, CamadaPisavel);
    }

    void Update()
    {
        eixoX = Input.GetAxis("Horizontal");
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if(quem.gameObject.tag == "Boost")
        {
            boost = true;
            DirecaoBoost = quem.gameObject.GetComponent<scrBoost>().LocalFinal;
        }
    }

    void OnTriggerExit2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "Boost")
        {
            boost = false;
            DirecaoBoost = null;
        }
    }
}
