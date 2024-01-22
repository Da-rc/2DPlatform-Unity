using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Clase para dialogo. Solo incluye nombre del personaje y su dialogo
[System.Serializable]
public class Dialog
{
    public string name;

    [TextArea(3, 10)]public string[] sentences;
}
