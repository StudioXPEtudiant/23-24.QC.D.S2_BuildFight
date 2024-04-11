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

    private RaycastHit _hit;
    
    //Quand je joueur clique sur le bouton gauche de la souris
    public void ActionateObjectFirstAction()
    {
        if(Camera.main == null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out _hit, distance)) return;
        
        _dialogue = _hit.collider.gameObject.GetComponent<Dialogue>();
        if (_dialogue)
            _dialogue.ShowNextLine();
    }
    
}
