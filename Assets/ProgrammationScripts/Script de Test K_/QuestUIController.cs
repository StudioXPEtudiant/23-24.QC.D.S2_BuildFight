using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    //[SerializeField] private int questMaxValue;
    [SerializeField] private int questValue;

    private int _currentQuestValue;

    private void Start()
    {
        gameObject.SetActive(false);
        _currentQuestValue = questValue;
    }

    public void UpdateQuestUI(int value)
    {
        text.text = value + "/1";
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        StartCoroutine(WaitBeforeHide());
    }

    private IEnumerator WaitBeforeHide()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
