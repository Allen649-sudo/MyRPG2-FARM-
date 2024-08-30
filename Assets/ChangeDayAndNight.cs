using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class ChangeDayAndNight : MonoBehaviour
{
    public Light2D _globalLight;
    private bool lightFalls = true; // ������
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
            _globalLight.intensity = 0.1f; // ����������� ������������ ��������
            lightFalls = false;
            lightRises = true; // �������� �����������
        }
    }

    void LightRises()
    {
        _globalLight.intensity += Time.deltaTime / timeDayChange;
        if (_globalLight.intensity >= 0.9f)
        {
            _globalLight.intensity = 0.9f; // ����������� ������������� ��������
            lightRises = false;
            lightFalls = true; // �������� ������
        }
    }
}
