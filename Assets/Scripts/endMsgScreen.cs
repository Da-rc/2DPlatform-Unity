using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Script para la escena del mensaje final cuando pasas el juego o pierdes todas las vidas
public class winScreen : MonoBehaviour
{
  
    void Start()
    {
        Invoke("nextScene", 4);
    }

    private void nextScene()
    {
        SceneManager.LoadScene(6);
    }
}
