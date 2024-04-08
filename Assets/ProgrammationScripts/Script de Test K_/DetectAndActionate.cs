using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectAndActionate : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layers;

    private Dialogue _dialogue;

    private RaycastHit hit;
    
    //Quand je joueur clique sur le bouton gauche ded la souris
    public void ActionateObjectFirstAction()
    {
        if(Camera.main == null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit, distance)) return;
        
        _dialogue = hit.collider.gameObject.GetComponent<Dialogue>();
        if (_dialogue)
            _dialogue.ShowDialogue();
    }
}
