using System;
using UnityEngine;

/// <summary>
/// Permet de gérer les dialogues des PNJ ainsi que les récompenses et objets pour la partie
/// </summary>
public class NPCDialogueCollection : MonoBehaviour
{
    [SerializeField] private Dialogue[] dialogues;

    private Dialogue _currentDialogue;
    private void Awake()
    {
        foreach (var dialogue in dialogues)
        {
            dialogue.objectPrice = GameObject.FindGameObjectWithTag("NextLvl");
            //dialogue.pickable = FindObjectOfType<PickableFunction>();
            dialogue.quest = FindObjectOfType<QuestUIController>();
        }
    }

    private void Start()
    {
        foreach (var dialogue in dialogues)
        {
            dialogue.objectPrice.SetActive(false);
            //dialogue.pickable.gameObject.SetActive(false);
            dialogue.quest.transform.GetChild(0).gameObject.SetActive(false);
        }
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