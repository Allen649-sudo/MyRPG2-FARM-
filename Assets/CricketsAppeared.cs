using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricketsAppeared : MonoBehaviour
{
    ComingNight comingNight;

    public ParticleSystem particleSystem;
    public List<ParticleSystem> particleSystemList = new List<ParticleSystem>();
    private int minCountCrickets = 4;
    private int maxCountCrickets = 8;
    public float fadeDuration = 2f;
    private bool fading = false;
    private Color basicColor = new Color(1f, 1f, 1f, 1f); // ������������� � ����� ������

    void Start()
    {
        comingNight = GetComponent<ComingNight>();
        particleSystem.Stop();
    }

    void Update()
    {
        if (fading)
        {
            FadeOut();
        }
    }

    void AddParticleSystemInList(ParticleSystem appeared)
    {
        particleSystemList.Add(appeared);
    }

    public void EnablingParticleSystem()
    {
        int countCrickets = Random.Range(minCountCrickets, maxCountCrickets);
        if (particleSystemList.Count > 0)
        {
            for (int i = 0; i < particleSystemList.Count; i++)
            {
                var main = particleSystemList[i].main; 
                main.startColor = basicColor;
                particleSystemList[i].Play();
            }
        }
        else
        {
            for (int i = 0; i < countCrickets; i++)  
            {
                ParticleSystem appeared = Instantiate(particleSystem, comingNight.GetRandomPosition(), Quaternion.identity);
                AddParticleSystemInList(appeared);
            }
        }
    }

    public void FadingParticleSystem()
    {
        fading = true;
    }

    private void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
        fading = false; 
    }

    private IEnumerator FadeOutCoroutine()
    {
        for (int i = 0; i < particleSystemList.Count; i++)  
        {
            var main = particleSystemList[i].main; // ��������� ������ �� MainModule
            AddParticleSystemInList(particleSystemList[i]);
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

            particleSystemList[i].Stop(); // ���������� ���������� ������� ������
        }

        particleSystemList.Clear(); // �������� ������ ������ ����� ���������� ��������
    }
}
