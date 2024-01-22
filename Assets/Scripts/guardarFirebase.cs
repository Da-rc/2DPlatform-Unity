using Firebase.Database;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firebaseManager : MonoBehaviour
{
    private TextMeshProUGUI puntosTxt;
    private int puntos = 0;

    public TMP_InputField input;

    private string nombre;

    private FirebaseManager fb;

    void Start()
    {
        puntosTxt = GameObject.Find("Puntos").GetComponent<TextMeshProUGUI>();
        puntos = PlayerPrefs.GetInt("Puntos");
        puntosTxt.text = ""+puntos;

        fb = new FirebaseManager();
    }


    public void guardarJugador()
    {
        nombre = input.text;
        fb.guardarJugador(nombre, puntos);
    }


    public void continuarSinGuardar() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
