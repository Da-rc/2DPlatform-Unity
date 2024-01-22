using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Para la animación de besos de los chicos "coleccionables" (no los de meta final). cuando colisionan con el jugador
public class Beso : MonoBehaviour
{

    private Animator anim;
    
  
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jugador") {
            anim.SetTrigger("KissCollect");
        }
    }
}
