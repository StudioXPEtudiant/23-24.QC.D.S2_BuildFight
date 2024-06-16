using System;
using TMPro;
using UnityEngine;
using System.Collections;
/// <summary>
/// Permet de controller l'affichage des quêtes en fonction de la longévité de celle-ci
/// </summary>
public class QuestUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    
    [SerializeField] private int questValue;
    
    public static QuestUIController Intance { get; private set; }

    private void Awake()
    {
        Intance = this;
    }

    private void Start()
    {
        Hide();
    }
    public void UpdateQuestUI(int value)
    {
        text.text = value + "/1";
    }
    public void Show()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void Hide()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}