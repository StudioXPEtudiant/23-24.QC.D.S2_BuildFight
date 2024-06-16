using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableFunction : MonoBehaviour
{
    [SerializeField] private int hitDamage;

    private Health _health;

    private void Awake()
    {
        _health = FindObjectOfType<Health>();
    }

    public void Attack()
    {
        _health.Decrease(hitDamage);
    }
}
