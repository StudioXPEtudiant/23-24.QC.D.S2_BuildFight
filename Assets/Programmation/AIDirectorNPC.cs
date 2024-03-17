using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIStateWandering))]
[RequireComponent(typeof(AIMovementFunctionAdvanced))]
public class AIDirectorNPC : MonoBehaviour
{
    private AIStateWandering stateWander;
    private AIMovementFunctionAdvanced movementFunction;
    private bool isStopped;

    void Awake()
    {
        stateWander = GetComponent<AIStateWandering>();
        movementFunction = GetComponent<AIMovementFunctionAdvanced>();
        isStopped = false;
    }

    void Update()
    {
        if(isStopped) return;
        stateWander.StateUpdate();
    }

    public void StopMovement()
    {
        movementFunction.StopMovement();
        isStopped = true;
        transform.LookAt(Camera.main.transform.position);
    }

    public void StartMovement()
    {
        isStopped = false;
    }
}
