using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timeSpeed;
    [SerializeField] private float startHour;
    //[SerializeField] private float sunriseHour;

    private float _currentTime; 
    private int _currentDay;

    void Awake()
    {
        _currentDay = 0;
        _currentTime = startHour;
    }

    void Update()
    {
        _currentTime +=  Time.deltaTime * timeSpeed;

        if(_currentTime > 24)
        {
            _currentTime -= 24;
            _currentDay++;

        }

        //Debug.Log("Il est " + (int)_currentTime + "h et nous sommes au jour " + _currentDay + ".");

        /*if (_currentTime >= sunriseHour)
        {
            
            float normalizedTime = (_currentTime - startHour) / (sunriseHour - startHour);

            
            Color sunriseColor = Color.yellow; 
            Color dawnColor = Color.blue; 
            Color lerpedColor = Color.Lerp(dawnColor, sunriseColor, normalizedTime);

        
            Debug.Log("Couleur au lever du soleil : " + lerpedColor);
        }*/
         
    }
        public float  CurrentTime
        {
            get
            {
                return _currentTime;
            }

        }

        public int  CurrentDay
        {
            get
            {
                return _currentDay;
            }

        }
            

        
}