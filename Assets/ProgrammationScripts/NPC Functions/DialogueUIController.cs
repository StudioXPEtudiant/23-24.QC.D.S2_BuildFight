using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIController : MonoBehaviour
{
    public static DialogueUIController Instance { get; private set; }

    [SerializeField] private Text text;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Show(string dialogue)
    {
        for(var i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
        text.text = dialogue;
    }

    public void Hide()
    {
        for (var i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }
}