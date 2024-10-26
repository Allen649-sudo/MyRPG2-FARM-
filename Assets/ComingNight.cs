using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComingNight : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject[] shootAreas;
    public CreaturesPool creaturesPool;
    private CricketsAppeared cricketsAppeared;

    public static Action OnCombustionCreatures;

    public AudioClip[] soundClipsDay;
    public AudioClip[] soundClipsNight;

    private List<Vector3> areaSizes = new List<Vector3>();
    private List<Vector3> areaCenters = new List<Vector3>();

    [SerializeField] private int minAmountMonster = 5;
    [SerializeField] private int maxAmountMonster = 12;

    private bool tryFallNight;
    private bool monstersSpawned; // Флаг для отслеживания статуса создания монстров
    private bool cricketsAppearedSpawned; // Флаг для отслеживания статуса создания кричащих существ

    void Start()
    {
        cricketsAppeared = GetComponent<CricketsAppeared>();

        foreach (var area in shootAreas)
        {
            var renderer = area.GetComponent<Renderer>();
            areaSizes.Add(renderer.bounds.size);
            areaCenters.Add(renderer.bounds.center);
        }

        // Проигрываем звуки дня в начале
        for (int i = 0; i < soundClipsDay.Length; i++)
        {
            AudioManager.Instance.PlaySound(soundClipsDay[i], default, 1f, true);
        }
    }

    void OnEnable()
    {
        ChangeDayAndNight.OnNightFall += OnNightFall;
        ChangeDayAndNight.OnDayComing += OnDayComing;
    }

    void OnDisable()
    {
        ChangeDayAndNight.OnNightFall -= OnNightFall;
        ChangeDayAndNight.OnDayComing -= OnDayComing;
    }

    void OnNightFall()
    {
        if (!monstersSpawned)
        {
            tryFallNight = true;
            AppearanceCreatures();
            if (!cricketsAppearedSpawned)
            {
                CricketsAppeared();
                cricketsAppearedSpawned = true;
            }
            HandleAuditoryFeedback(); // Выносим управление звуками в отдельный метод
            monstersSpawned = true;
        }
    }

    void OnDayComing()
    {
        tryFallNight = false;
        OnCombustionCreatures?.Invoke();
        cricketsAppeared.FadingParticleSystem();
        HandleAuditoryFeedback(); // Выносим управление звуками в отдельный метод
        monstersSpawned = false;
        cricketsAppearedSpawned = false;
    }

    private void HandleAuditoryFeedback()
    {
        Mute();   
        Unmute();
    }

    private void CricketsAppeared()
    {
        cricketsAppeared.EnablingParticleSystem();
    }

    private void AppearanceCreatures()
    {
        int amountMonster = UnityEngine.Random.Range(minAmountMonster, maxAmountMonster);
        for (int i = 0; i < amountMonster; i++)
        {
            if (creaturesPool != null)
            {
                creaturesPool.GetComponent<CreaturesPool>().ActivateCreatures(monsterPrefab, GetRandomPosition());
            }
        }
    }

    public Vector3 GetRandomPosition()
    {
        int randomIndex = UnityEngine.Random.Range(0, areaSizes.Count);
        Vector3 areaSize = areaSizes[randomIndex];
        Vector3 areaCenter = areaCenters[randomIndex];

        return new Vector3(
            UnityEngine.Random.Range(areaCenter.x - areaSize.x / 2, areaCenter.x + areaSize.x / 2),
            UnityEngine.Random.Range(areaCenter.y - areaSize.y / 2, areaCenter.y + areaSize.y / 2),
            areaCenter.z);
    }

    private void Unmute()
    {
        if (tryFallNight)
        {
            for (int i = 0; i < soundClipsNight.Length; i++)
            {
                AudioManager.Instance.PlaySound(soundClipsNight[i], default, 1f, true);
            }
        }
        else
        {
            for (int i = 0; i < soundClipsDay.Length; i++)
            {
                AudioManager.Instance.PlaySound(soundClipsDay[i], default, 1f, true);
            }
        }
    }

    private void Mute()
    {
        if (!tryFallNight)
        {
            for (int i = 0; i < soundClipsNight.Length; i++)
            {
                AudioManager.Instance.FadeSound(soundClipsNight[i]);
            }
        }
        else
        {
            for (int i = 0; i < soundClipsDay.Length; i++)
            {
                AudioManager.Instance.FadeSound(soundClipsDay[i]);
            }
        }
    }
}
