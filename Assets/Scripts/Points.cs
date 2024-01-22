using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Clase para controlar los puntos y poder sumarlos desde diferentes scripts
public class Points
{
    public static int puntos;

    private TextMeshProUGUI puntosText;


    public Points() 
    {
        puntos = PlayerPrefs.GetInt("Puntos");
        puntosText = GameObject.Find("Puntos_text").GetComponent<TextMeshProUGUI>();
        puntosText.text = "Puntos: " + puntos;
    }

    public void mostrarPuntos() 
    {
        puntosText.text = "Puntos: " + puntos;
    }

    public void sumarPuntos(int x)
    {
        puntos = PlayerPrefs.GetInt("Puntos");
        puntos += x;
        PlayerPrefs.SetInt("Puntos", puntos);
    }
}
