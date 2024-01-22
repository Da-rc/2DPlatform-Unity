using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Script para todos los coleccionables del juego

public class ItemCollector : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;

    private Points puntos;

    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private AudioSource collectionKissEffect;

    private void Start()
    {
        puntos=new Points();
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            puntos.sumarPuntos(50);
            puntos.mostrarPuntos();
        }
        
        if (collision.gameObject.CompareTag("boy"))
        {
            collectionKissEffect.Play();
            Destroy(collision.gameObject, 1f);
            puntos.sumarPuntos(100);
            puntos.mostrarPuntos();
            player.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("KissCollect");
        }

        //Para parar al jugador en cuanto se activa el trigger de conversación y evitar problemas porque el jugador se siga moviendo
        if (collision.gameObject.CompareTag("dialogo"))
        {
            player.bodyType = RigidbodyType2D.Static;
            Invoke("DynamicBody", 2);
        }

    }

    private void EndKiss() {
        player.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("EndKissCollect");
    }

    private void DynamicBody() {
        player.bodyType = RigidbodyType2D.Dynamic;
    }
}
