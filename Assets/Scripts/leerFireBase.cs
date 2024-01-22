using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leerFireBase : MonoBehaviour
{

    private DatabaseReference dbReference;


    [SerializeField] private List<TextMeshProUGUI> listaNombres;
    [SerializeField] private List<TextMeshProUGUI> listaPuntos;

    private List<Jugador> listaJugadores = new();

    void Start()
    {
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        StartCoroutine(Leer());
    }

    private IEnumerator Leer() {
        var dbTask=dbReference.Child("users").OrderByChild("puntos").GetValueAsync();

        yield return new WaitUntil(predicate: () => dbTask.IsCompleted);
           
        if (dbTask.Exception != null)
        {
            Debug.Log("error");
        }
        else
        {
            DataSnapshot snapshot = dbTask.Result;

            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                string nombre = childSnapshot.Child("nombre").Value.ToString();
                int punto = int.Parse(childSnapshot.Child("puntos").Value.ToString());

                Jugador newJugador = new Jugador(nombre, punto);

                listaJugadores.Add(newJugador);
            }

            for (int i = 0; i < listaNombres.Count; i++)
            {
                listaNombres[i].text = listaJugadores[i].nombre;
                listaPuntos[i].text = listaJugadores[i].puntos.ToString();
            }
        }
    }
}
