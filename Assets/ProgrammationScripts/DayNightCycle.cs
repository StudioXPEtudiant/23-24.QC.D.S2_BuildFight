using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private Light sun;    
    [SerializeField] private Light moon;

    private float _sunMaxIntensity;
    private float _moonMaxIntensity;
    private float _rotX = 0; 
    
        private float _HeureMatin = 6; // L'heure où se lève le soleil
        private float _DegreMatin = 0; // Le degré du soleil au levé du soleil
        private float _HeureMidi = 12; // L'heure où le soleil est à son plus haut
        private float _DegreMidi = 90; // Le degré du soleil à son plus haut
        private float _HeureNuit = 22; // L'heure où le soleil se couche complètement
        private float _DegreNuit = 270; // Le degré du soleil au moment de se coucher complètement
        private float _VitesseMatin; // La vitesse de rotation le matin
        private float _VitessePM; // La vitesse de rotation l'apris midi
        private float _VitesseNuit; // La vitesse de rotation la nuit
        private float _PositionMinuit; // Le calcul du degré du départ du soleil à minuit
     
    void Awake()
    {
        _sunMaxIntensity = sun.intensity;
        _moonMaxIntensity = moon.intensity;

       _VitesseMatin = (_DegreMidi - _DegreMatin) / (_HeureMidi - _HeureMatin);
       _VitessePM = (_DegreNuit - _DegreMidi) / (_HeureNuit - _HeureMidi);
       _VitesseNuit = (360 - _DegreNuit) / (24 - _HeureNuit + _HeureMatin);
       _PositionMinuit = ((24-_HeureNuit)*_VitesseNuit) + _DegreNuit;
    }

    public void UpdateSun(Light light, float rotX, float maxIntensity)
    {
        light.transform.localEulerAngles = new Vector3(rotX,0,0);
        light.gameObject.SetActive(true);

        if(rotX<0 || rotX > 180)
        {
            light.gameObject.SetActive(false);
        }
        else
        {
            light.gameObject.SetActive(true);
        }

    }

    public void UpdateMoon(Light light, float rotX, float maxIntensity)
    {
        light.transform.localEulerAngles = new Vector3(rotX,0,0);

        if(rotX<90 || rotX > 270)
        {
            light.gameObject.SetActive(false);
        }
        else
        {
            light.gameObject.SetActive(true);
        }
    }
    void Update()
    {

        // Entre le matin et le midi
        if (timeManager.CurrentTime >= _HeureMatin && timeManager.CurrentTime < _HeureMidi) 
        { 
            // Avance à la vitesse du matin
            _rotX += timeManager.CurrentTime * _VitesseMatin;
        }
        // Entre le midi et le soir
        else if (timeManager.CurrentTime >= _HeureMidi && timeManager.CurrentTime < _HeureNuit) 
        {
            // Avance à la vitesse du soir
            _rotX += timeManager.CurrentTime * _VitessePM; 
        }
        else
        {
            // Le reste du temps, vitesse de nuit
            _rotX += timeManager.CurrentTime * _VitesseNuit;
        }
        
        // Quand le soleil passe droit, on revient à 0
        if (_rotX > 360)
        { 
            _rotX = 0;
        }


        // rotX = un degré selon l'heure
        //float rotX = 0;
        if (timeManager.CurrentTime > 6 || timeManager.CurrentTime < 22) {
            _rotX = timeManager.CurrentTime * 12;
        } else {
            _rotX = timeManager.CurrentTime * 20;
        }

        if (_rotX > 360) {
            _rotX = 0;
        }

        UpdateSun(sun, _rotX, _sunMaxIntensity);

        float moonRotX = _rotX + 180;
        if (moonRotX > 360)
        {
            moonRotX -= 360;
        }

        UpdateMoon(moon, moonRotX, _moonMaxIntensity);
    }
}
