using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Menu final
public class SalirGameOver : MonoBehaviour
{
    public void salir() {
        Application.Quit();
    }

    public void volverAJugar() {
        SceneManager.LoadScene(0);
    }
}
