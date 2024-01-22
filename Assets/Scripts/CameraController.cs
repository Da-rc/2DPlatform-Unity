using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script para que la camara siga al personaje principal
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
