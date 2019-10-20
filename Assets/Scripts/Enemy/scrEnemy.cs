using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrEnemy : MonoBehaviour
{
    public bool Found;
    private float scale;
    public float Velo;
    public GameObject LimitD, LimitE;
    public int Direcao;
    private Rigidbody2D rbEnemy;

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;
    }
    

    void Update()
    {
        if (!Found)
        {
            if (transform.position.x >= LimitD.transform.position.x)
            {
                Direcao = -1;
                transform.localScale = new Vector3(scale * -1, transform.localScale.y, transform.localScale.z);
            }

            if (transform.position.x <= LimitE.transform.position.x)
            {
                Direcao = 1;
                transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            }

            rbEnemy.velocity = new Vector2(Velo * Direcao, rbEnemy.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            //Destroy(collision.gameObject);
            Found = true;
            rbEnemy.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            //Destroy(collision.gameObject);
            Found = false;
            rbEnemy.constraints = ~RigidbodyConstraints2D.FreezePositionX;
            Debug.Log("Saiu");
        }
    }
}
