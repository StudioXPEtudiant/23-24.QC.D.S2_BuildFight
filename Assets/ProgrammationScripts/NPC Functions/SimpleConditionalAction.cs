using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Permet de gérer les dialogues des PNJ suivant les quêtes
/// </summary>
public class SimpleConditionalAction : MonoBehaviour
{
    [SerializeField] private string[] requiredFlags;
    [SerializeField] private UnityEvent action;
    [SerializeField] private UnityEvent actionIfNotCompleted;

    public bool IsAvailable => requiredFlags.All(flag => SimpleGameFlagCollection.Instance.IsTriggered(flag));

    public void Execute()
    {
        if (IsAvailable) action.Invoke();
        else actionIfNotCompleted.Invoke();
    }
}
