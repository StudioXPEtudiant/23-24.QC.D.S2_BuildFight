using System;
using UnityEngine;

public class NPCDialogueCollection : MonoBehaviour
{
    [SerializeField] private Dialogue[] dialogues;
    //[SerializeField] private PickableFunction price;

    private Dialogue _currentDialogue;
    //private PickableFunction _pickable;
    private void Awake()
    {
        foreach (var dialogue in dialogues)
        {
            dialogue.pickable = GetComponentInChildren<PickableFunction>();
        }
        //price = FindObjectOfType<PickableFunction>();
    }

    private void Start()
    {
        foreach (var dialogue in dialogues)
        {
            dialogue.pickable.gameObject.SetActive(false);
        }
        
        //price.gameObject.SetActive(false);
    }

    public void Execute()
    {
        foreach (var dialogue in dialogues)
        {
            dialogue.panel.gameObject.SetActive(true);
            if(!dialogue.IsAvailable) continue;

            dialogue.ShowNextLine(); 
            return;
        }
    }
}