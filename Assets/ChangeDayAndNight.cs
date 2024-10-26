using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;


public class ChangeDayAndNight : MonoBehaviour
{
    public Light2D _globalLight;
    private bool lightFalls = true; 
    private bool lightRises = false;

    private int timeDayChange = 540;

    public static Action OnNightFall;
    public static Action OnDayComing;
    private bool hasDayCome = false;
    private bool hasNightFallen = false;

    private float comingDay = 0.9f;
    private float comingNight = 0.05f;
    private float lineBetweenDayAndNight = 0.45f;

    void Start()
    {
        _globalLight = GetComponent<Light2D>();
    }

    void Update()
    {
        if (lightFalls)
        {
            LightFalls();
        }
        else if (lightRises)
        {
            LightRises();
        }
        
    }

    void LightFalls()
    {
        _globalLight.intensity -= Time.deltaTime / timeDayChange;

        if (_globalLight.intensity <= comingNight)
        {
            _globalLight.intensity = comingNight; 
            lightFalls = false;
            lightRises = true;
            hasDayCome = false; 
        }

        if (_globalLight.intensity < lineBetweenDayAndNight && !hasNightFallen)
        {
            OnNightFall?.Invoke();
            hasNightFallen = true; 
        }
    }

    void LightRises()
    {
        _globalLight.intensity += Time.deltaTime / timeDayChange;

        if (_globalLight.intensity >= comingDay)
        {
            _globalLight.intensity = comingDay; 
            lightRises = false;
            lightFalls = true; 
            hasNightFallen = false;
        }

        if (_globalLight.intensity > lineBetweenDayAndNight && !hasDayCome)
        {
            OnDayComing?.Invoke();
            hasDayCome = true; 
        }
    }
}
