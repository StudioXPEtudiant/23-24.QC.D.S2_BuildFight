using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerV2 : MonoBehaviour
{
    [SerializeField] private float timeSpeed;
    [SerializeField] private float startHour;

    private float _currentTime; 
    private int _currentDay;

    private Light sunLight; // Référence à la lumière directionnelle

    void Awake()
    {
        _currentDay = 0;
        _currentTime = startHour;

        // Récupérer la référence à la lumière directionnelle dans la scène
        sunLight = GameObject.FindWithTag("Sun").GetComponent<Light>();
    }

    void Update()
    {
        _currentTime +=  Time.deltaTime * timeSpeed;

        if(_currentTime > 24)
        {
            _currentTime -= 24;
            _currentDay++;
        }

        // Vérifier si la rotation de la lumière est un multiple de 15 degrés
        if (sunLight.transform.rotation.eulerAngles.y % 15 == 0)
        {
            Debug.Log("Il est " + (int)_currentTime + "h et nous sommes au jour " + _currentDay + ".");
        }
    }

    public float CurrentTime
    {
        get
        {
            return _currentTime;
        }
    }

    public int CurrentDay
    {
        get
        {
            return _currentDay;
        }
    }
}