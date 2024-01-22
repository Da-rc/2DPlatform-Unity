using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Para la rotaci�n de objetos. En este caso para la trampa de sierra
public class Rotate : MonoBehaviour
{
    private float speed = 2f;
    
    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
