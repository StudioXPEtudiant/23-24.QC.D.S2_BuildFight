using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


public class Health : MonoBehaviour
{
    [SerializeField] private int health;

    private Spawner _spawner;

    private int _currentHealth;

    private void Start()
    {
        _spawner = GetComponent<Spawner>();
        _currentHealth = health;
    }

    public void Decrease(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _spawner.Spawn();
            Destroy(gameObject);
        }
    }
}
