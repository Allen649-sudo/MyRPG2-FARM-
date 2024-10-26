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
    private Color basicColor = new Color(1f, 1f, 1f, 1f); // Инициализация с белым цветом

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
            var main = particleSystemList[i].main; // Сохраните ссылку на MainModule
            AddParticleSystemInList(particleSystemList[i]);
            // Время затухания
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                float normalizedTime = t / fadeDuration;

                // Изменяем альфа-канал цвета частиц
                Color startColor = main.startColor.color; // Получаем текущий цвет
                startColor.a = Mathf.Lerp(1, 0, normalizedTime); // Линейно интерполируем альфа
                main.startColor = startColor; // Устанавливаем измененный цвет

                yield return null;
            }

            // Гарантируем, что цвет полностью прозрачный
            Color finalColor = main.startColor.color;
            finalColor.a = 0;
            main.startColor = finalColor;

            particleSystemList[i].Stop(); // Остановить конкретную систему частиц
        }

        particleSystemList.Clear(); // Очистить список частиц после завершения угасания
    }
}
