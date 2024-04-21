using System;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Modules;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Events;

[Serializable]
public class Dialogue
{
    //La configuration du dialogue
    [FoldoutGroup("Configuration"), SerializeField] private bool isRepeatable;
    // Les lignes de dialogue du PNJ
    [FoldoutGroup("Dialogue"), SerializeField] private string[] dialogueLines;
    
    // Référence au composant du text pour afficher le dialogue
    [FoldoutGroup("Parameters"), SerializeField] private Text dialogueText;
    [FoldoutGroup("Parameters"), SerializeField] public GameObject panel;
    [FoldoutGroup("Parameters"), SerializeField] private UnityEvent dialogueEnd;
    //[FoldoutGroup("Parameters"), SerializeField] private PickableFunction pickable;//Object  a faire spawn;
    
    private int _currentLine = 0; // La ligne de dialogue actuelle
    private bool _isCompleted; //Vérifie si les dialoques sont tous jouer
    private bool _isActive = false;

    public bool IsAvailable => !_isCompleted;
    //public bool IsCompeted => _isCompleted = true;
    
    public bool ShowNextLine()
    {
        if (_isCompleted) return false;
        
        if(!_isActive) Init();
        
        if (_currentLine < dialogueLines.Length)
        {
            DialogueUIController.Instance.Show(dialogueLines[_currentLine++]);
        }
        else if(_currentLine >= dialogueLines.Length)
        {
            if (!isRepeatable)
                _isCompleted = true;
            
            _isActive = false;
            
            dialogueEnd.Invoke();
            DialogueUIController.Instance.Hide();
            return false;
        }
        
        return true;
    }

    /*public void ShowPrice()
    {
        pickable.gameObject.SetActive(true);
    }*/

    private void Init() 
    {
        _currentLine = 0;
        _isActive = true;
    }
}