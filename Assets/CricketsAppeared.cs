using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricketsAppeared : MonoBehaviour
{
    ComingNight comingNight;

    public ParticleSystem particleSystem;
    private int minCountCrickets = 4;
    private int maxCountCrickets = 8;
    public float fadeDuration = 20f;
    private bool fading = false;


    void Start()
    {
        comingNight = GetComponent<ComingNight>();

        particleSystem.Stop();
    }

   /* void Update()
    {
        if(fading)
        {
            FadeOut();
        }
    }*/

    public void EnablingParticleSystem()
    {
        int countCrickets = Random.Range(minCountCrickets, maxCountCrickets);
        for (int i = 0; i <= countCrickets; i++)
        {
            Instantiate(particleSystem, comingNight.GetRandomPosition(), Quaternion.identity);
        }
    }

    public void FadingParticleSystem()
    {
        fading = true;
    }

    private void FadeOut()
    {
        Debug.Log("Fading");

        /*StartCoroutine(FadeOutCoroutine());*/
    }

    /*private IEnumerator FadeOutCoroutine()
    {
        var main = particleSystem.main; // ��������� ������ �� MainModule
        ParticleSystemRenderer renderer = particleSystem.GetComponent<ParticleSystemRenderer>();

        // ����� ���������
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;

            // �������� �����-����� ����� ������
            Color startColor = main.startColor.color; // �������� ������� ����
            startColor.a = Mathf.Lerp(1, 0, normalizedTime); // ������� ������������� �����
            main.startColor = startColor; // ������������� ���������� ����

            yield return null;
        }

        // �����������, ��� ���� ��������� ����������
        Color finalColor = main.startColor.color;
        finalColor.a = 0;
        main.startColor = finalColor;

        particleSystem.Stop();
    }*/
}
