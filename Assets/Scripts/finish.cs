using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script para pasar al siguiente nivel cuando se besa al chico de la meta
//suma tmb los puntos por llegar a la meta
public class finish : MonoBehaviour
{
    [SerializeField]private AudioSource finishSound;
    private Rigidbody2D player;
    private Animator anim;
    private Points puntos;

    private void Start()
    {
        finishSound= GetComponent<AudioSource>();
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        puntos= new Points();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "meta") {
            finishSound.Play();
            puntos.sumarPuntos(150);
            puntos.mostrarPuntos();
            player.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("Kiss");
        }
    }

    private void completeLevel() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
