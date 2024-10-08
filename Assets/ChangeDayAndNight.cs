using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;


public class ChangeDayAndNight : MonoBehaviour
{
    public Light2D _globalLight;
    private bool lightFalls = true; // падает
    private bool lightRises = false;

    private int timeDayChange = 480;

    public static Action OnNightFall;
    public static Action OnDayComing;
    private bool hasDayCome = false; // флаг для события дня
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
            _globalLight.intensity = comingNight; // ограничение минимального значения
            lightFalls = false;
            lightRises = true; // начинаем подниматься
            hasDayCome = false; // сброс флага дня при переходе в ночь
        }

        // Вызов события при переходе через порог 0.3f, только если оно еще не было вызвано
        if (_globalLight.intensity < lineBetweenDayAndNight && !hasNightFallen)
        {
            OnNightFall?.Invoke();
            hasNightFallen = true; // устанавливаем флаг, чтобы событие больше не вызывалось
        }
    }

    void LightRises()
    {
        _globalLight.intensity += Time.deltaTime / timeDayChange;

        if (_globalLight.intensity >= comingDay)
        {
            _globalLight.intensity = comingDay; // ограничение максимального значения
            lightRises = false;
            lightFalls = true; // начинаем падать
            hasNightFallen = false;
        }

        // Вызов события при переходе через порог 0.3f, только если оно еще не было вызвано
        if (_globalLight.intensity > lineBetweenDayAndNight && !hasDayCome)
        {
            OnDayComing?.Invoke();
            hasDayCome = true; // устанавливаем флаг, чтобы событие больше не вызывалось
        }
    }
}
