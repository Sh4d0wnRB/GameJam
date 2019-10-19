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

    [Header("Movimentação")]
    public float velocidadeCorrendo;
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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                aceleracao = velocidadeCorrendo * eixoX;
                rbPlayerAutista.velocity = new Vector2(aceleracao, rbPlayerAutista.velocity.y);
                rbPlayerAutista.gravityScale = 1f;
            }
            else
            {
                aceleracao = velocidadeNormal * eixoX;
                rbPlayerAutista.velocity = new Vector2(aceleracao, rbPlayerAutista.velocity.y);
                rbPlayerAutista.gravityScale = 7f;
            }
            if(Input.GetButtonDown("Jump"))
            {
                rbPlayerAutista.AddForce(new Vector2(0f, Pulo), ForceMode2D.Impulse);
            }
        }

        NoChao = Physics2D.OverlapCircle(LocalPe.transform.position, radius, CamadaPisavel);
    }

    void Update()
    {
        eixoX = Input.GetAxis("Horizontal");
    }
}
