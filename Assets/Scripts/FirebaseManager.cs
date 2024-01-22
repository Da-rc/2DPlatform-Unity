using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirebaseManager 
{
    private string key;
    private DatabaseReference dbReference;

    public FirebaseManager() {
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        key = dbReference.Child("users").Push().Key;
    }

    public void guardarJugador(string nombre, int puntos) {
       
        if (nombre != "")
        {
            Jugador newJugdor = new Jugador(nombre, puntos);
            string json = JsonUtility.ToJson(newJugdor);

            dbReference.Child("users").Child(key).SetRawJsonValueAsync(json);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
