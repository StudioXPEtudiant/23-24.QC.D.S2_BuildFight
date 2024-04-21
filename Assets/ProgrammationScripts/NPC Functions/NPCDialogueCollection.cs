using System;
using UnityEngine;

public class NPCDialogueCollection : MonoBehaviour
{
    [SerializeField] private Dialogue[] dialogues;

    private Dialogue _currentDialogue;
    private RaycastHit _hit;
    //private PickableFunction _pickable;

    /*private void Awake()
    {
        _pickable = GetComponentInChildren<PickableFunction>();
    }

    private void Start()
    {
        _pickable.gameObject.SetActive(false);
    }*/

    public void Execute()
    {
        foreach (var dialogue in dialogues)
        {
            dialogue.panel.gameObject.SetActive(true);
            if(!dialogue.IsAvailable) continue;

            dialogue.ShowNextLine(); 
            //if(!dialogue.IsCompeted) dialogue.ShowPrice();
            return;
        }
    }
}