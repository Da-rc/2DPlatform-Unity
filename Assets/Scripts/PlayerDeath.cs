using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Script que controla las vidas y el respawn
public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private Transform respawnPoint;//donde aparecerá el personaje si muere y le quedan vidas


    //booleano extra para asegurar que solo pierde una vida cada vez
    private Boolean isAlive;

    //Instancia de la clase Vidas
    private Vidas vidaAct;

    private Image imagen;
    [SerializeField]public Sprite tresVidas;
    [SerializeField] public Sprite dosVidas;
    [SerializeField] public Sprite unaVida;
    [SerializeField] public Sprite ceroVidas;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        player=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        respawnPoint = GameObject.FindWithTag("Respawn").transform;

        isAlive = true;

        //para detectar la imagen donde iremos cambiando los sprites
        imagen = GameObject.Find("vidas").GetComponent<Image>();
       
        vidaAct = new Vidas();
        cambiarImagenVida(vidaAct.getVidas());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampa") || collision.gameObject.CompareTag("Vacio"))
        {
            if (isAlive)
            {
                isAlive = false;
                Die();
            }
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        player.bodyType = RigidbodyType2D.Static;//convierte a estatico para que no se pueda mover mientras está muriendo
       
        //Restamos una vida y cambiamos la imagen de los corazones
        vidaAct.restarVida();
        cambiarImagenVida(vidaAct.getVidas());

        //lanzamos la animacion de muerte
        anim.SetTrigger("Muerte");
    }

    private void RestartLever() {//A este metodo se le llama desde la animación de muerte
        if (vidaAct.getVidas() < 1)
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            player.bodyType = RigidbodyType2D.Dynamic;//al morir lo ponemos estatico, por lo que aquí debemos volver a ponerlo dinamico
            player.transform.position = respawnPoint.position;
            isAlive = true;
            anim.SetTrigger("Respawn");
        }
        
    }

    private void cambiarImagenVida(int vidas) {
        if (vidas < 1)
        {
            imagen.sprite = ceroVidas;
        }
        else if (vidas == 1)
        {
            imagen.sprite = unaVida;
        }
        else if (vidas == 2)
        {
            imagen.sprite = dosVidas;
        }
        else {
            imagen.sprite = tresVidas;
        }
    }
}
