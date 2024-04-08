using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string[] dialogueLines; // Les lignes de dialogue du PNJ
    public Text dialogueText; // Référence au composant texte pour afficher le dialogue
    private int currentLine = 0; // La ligne de dialogue actuelle
    public GameObject panel;
    //public float range;
    //public LayerMask layermask;

    void Start()
    {
        dialogueText.gameObject.SetActive(false); // Désactive le texte de dialogue au début
        panel.SetActive(false); // Désactive le panel au début
    }

    void Update()
    {
       
    }

    public void ShowDialogue()
    {
        // Vérifie s'il reste des lignes de dialogue à afficher
        if (currentLine < dialogueLines.Length)
        {
            // Affiche la prochaine ligne de dialogue
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;
            panel.SetActive(true);
            dialogueText.gameObject.SetActive(true);
        }
        else
        {
            // Cache le texte de dialogue s'il n'y a plus de lignes à afficher
            dialogueText.gameObject.SetActive(false);
            panel.SetActive(false);


        }
    }
}
