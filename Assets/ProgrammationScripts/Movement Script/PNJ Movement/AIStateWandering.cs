using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateWandering : MonoBehaviour
{
private bool _waiting;

[SerializeField] private float range = 5;
[SerializeField] private float minWaitTime = 0;
[SerializeField] private float maxWaitTime = 2;

private AIMovementFunctionAdvanced _aiMovement;

private void Awake()
{
_aiMovement = GetComponent<AIMovementFunctionAdvanced>();
}

public void StateUpdate()
{
if (_waiting) return;

_waiting = true;

_aiMovement.MoveToRandom(transform.position, range);
StartCoroutine(Wait());
}

private IEnumerator Wait()
{
yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
_waiting = false;
}
}
