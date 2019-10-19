using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerAutistc : MonoBehaviour
{
    [Header("Pulo")]
    public GameObject LocalPe;
    public bool NoChao;
    public float radius, Pulo;
    public LayerMask CamadaPisavel;
    public float ChaoTouchVel;

    [Header("Movimentação")]
    public bool naRampa;
    public float velocidadeNormal;
    private float eixoX;
    private float aceleracao;
    Rigidbody2D rbPlayerAutista;

    void Start()
    {
        rbPlayerAutista = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (NoChao)
        {
            if (ChaoTouchVel <= -20)
            {
                Destroy(gameObject);
            }

            if (Input.GetButtonDown("Jump"))
            {
                rbPlayerAutista.AddForce(new Vector2(0f, Pulo), ForceMode2D.Impulse);
            }
        }
        else
        {
            ChaoTouchVel = rbPlayerAutista.velocity.y;
        }
        if (!naRampa || NoChao)
        {
            aceleracao = velocidadeNormal * eixoX;
            rbPlayerAutista.velocity = new Vector2(aceleracao, rbPlayerAutista.velocity.y);
        }
        
        NoChao = Physics2D.OverlapCircle(LocalPe.transform.position, radius, CamadaPisavel);
    }

    void Update()
    {
        eixoX = Input.GetAxis("Horizontal");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Rampa")
        {
            naRampa = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rampa")
        {
            naRampa = false;
        }
    }
}
