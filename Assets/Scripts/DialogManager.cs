using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
//Script que controla el dialogo y la velocidad a la que se escribe el texto
public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;

    public Animator animator;

    private Image imagen;

    private Queue<string> sentences;

    void Start()
    {
        sentences=new Queue<string>();
        imagen=GameObject.Find("npc").GetComponent<Image>();
    }

    public void StartDialogue(Dialog dialog, Sprite npc)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialog.name;
        imagen.sprite = npc;
        sentences.Clear();

        //Guarda las sentencias en el queque
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //llama a este metodo que las muestre
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
        }

        string sentence=sentences.Dequeue();
        //Paramos todas la coroutines en caso de que pulse el boton de continuar
        StopAllCoroutines();
        //coroutine para escribir la frase
        StartCoroutine(TypeSentence(sentence));

        //dialogText.text = sentence;
    }

    //para que el texto se escriba letra a letra
    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }

}
