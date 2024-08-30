using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class ChangeDayAndNight : MonoBehaviour
{
    public Light2D _globalLight;
    private bool lightFalls = true; // падает
    private bool lightRises = false;

    private int timeDayChange = 360;

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
        if (_globalLight.intensity <= 0.1f)
        {
            _globalLight.intensity = 0.1f; // ограничение минимального значения
            lightFalls = false;
            lightRises = true; // начинаем подниматься
        }
    }

    void LightRises()
    {
        _globalLight.intensity += Time.deltaTime / timeDayChange;
        if (_globalLight.intensity >= 0.9f)
        {
            _globalLight.intensity = 0.9f; // ограничение максимального значения
            lightRises = false;
            lightFalls = true; // начинаем падать
        }
    }
}
