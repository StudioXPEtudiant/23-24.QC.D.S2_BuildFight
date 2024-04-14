using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class NPCDialogueCollection : MonoBehaviour
{
    [SerializeField] private Dialogue[] dialogues;

    private Dialogue _currentDialogue;
    private RaycastHit _hit;
    

    public void Execute()
    {
        foreach (var dialogue in dialogues)
        {
            dialogue.panel.gameObject.SetActive(true);
            if(!dialogue.IsAvailable) continue;

            dialogue.ShowNextLine(); return;
        }
    }

    public void Open()
    {
        foreach (var dialogue in dialogues)
        {
            dialogue.panel.gameObject.SetActive(true);
        }
    }
}