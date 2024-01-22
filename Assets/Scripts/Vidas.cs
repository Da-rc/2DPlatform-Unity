using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas
{
    private static int vidas;

    public Vidas()
    {
        leerVidas();
    }

    private void leerVidas()
    {
        vidas = PlayerPrefs.GetInt("Vidas");
    }

    public void restarVida() 
    {
        leerVidas();
        vidas--;
        PlayerPrefs.SetInt("Vidas", vidas);
    }

    public int getVidas() 
    {
        leerVidas();
        return vidas;
    }
}
