using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jugador
{
    public string nombre;
    public int puntos;

    public Jugador(string nombre, int puntos)
    {
        this.nombre = nombre;
        this.puntos = puntos;
    }


    public string getNombre()
    {
        return nombre;
    }

    public int getPuntos()
    {
        return puntos;
    }
}
