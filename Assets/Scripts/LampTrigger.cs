using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Trigger para el encendido de las lamparas en el nivel 3
public class LampTrigger : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            anim.SetBool("isLight", true);
        }
    }
}
