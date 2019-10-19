using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerManager : MonoBehaviour
{
    public int Player;
    public GameObject Player1;
    public GameObject Player2;

    void Start() => DontDestroyOnLoad(gameObject);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(GameObject.FindGameObjectWithTag("Player1") != null && GameObject.FindGameObjectWithTag("Player1").GetComponent<scrPlayerAutistc>().NoChao)
            {
                Player = 2;
                Instantiate(Player2, GameObject.FindGameObjectWithTag("Player1").transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Player1"));
            }
            else if(GameObject.FindGameObjectWithTag("Player2") != null && GameObject.FindGameObjectWithTag("Player2").GetComponent<scrPlayerCadeirante>().NoChao && !GameObject.FindGameObjectWithTag("Player2").GetComponent<scrPlayerCadeirante>().moving)
            {
                Player = 1;
                Instantiate(Player1, GameObject.FindGameObjectWithTag("Player2").transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Player2"));
            }
        }
    }
}
