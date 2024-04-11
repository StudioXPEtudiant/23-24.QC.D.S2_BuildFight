using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private string[] dialogueLines; // Les lignes de dialogue du PNJ
    [SerializeField] private Text dialogueText; // Référence au composant texte pour afficher le dialogue
    
    [SerializeField] private GameObject panel;
    private Spawner _spawner;

    //[SerializeField] private UnityEvent endDialogue;
    
    private int _currentLine = 0; // La ligne de dialogue actuelle

    private void Awake()
    {
        _spawner = GetComponentInChildren<Spawner>();
    }

    void Start()
    {
        dialogueText.gameObject.SetActive(false); // Désactive le texte de dialogue au début
        panel.SetActive(false); // Désactive le panel au début
    }

    void Update()
    {
       //CheckDialoguesOfPnj();
    }

    public void ShowNextLine()
    {
        // Vérifie s'il reste des lignes de dialogue à afficher
        
        if (_currentLine < dialogueLines.Length)
        {
            // Affiche la prochaine ligne de dialogue
            
            DialogueUIController.Instance.Show(dialogueLines[_currentLine++]);
            panel.SetActive(true);
            dialogueText.gameObject.SetActive(true);
        }
        else if(_currentLine >= dialogueLines.Length)
        {
            // Cache le texte de dialogue s'il n'y a plus de lignes à afficher

            //endDialogue.Invoke();
            _spawner.Spawn();
            DialogueUIController.Instance.Hide();
        }
    }
    
    
}
