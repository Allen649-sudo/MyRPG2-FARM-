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

    public AudioClip[] soundClips;

    private List<Vector3> areaSizes = new List<Vector3>(); 
    private List<Vector3> areaCenters = new List<Vector3>();

    [SerializeField] private int minAmountMonster = 5;
    [SerializeField] private int maxAmountMonster = 12;

    void Start()
    {
        cricketsAppeared = GetComponent<CricketsAppeared>();

        foreach (var area in shootAreas)
        {
            var renderer = area.GetComponent<Renderer>();
            areaSizes.Add(renderer.bounds.size);
            areaCenters.Add(renderer.bounds.center);
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
        AppearanceCreatures();
        CricketsAppeared();
        Unmute();
    }

    void OnDayComing()
    {
        OnCombustionCreatures?.Invoke();
        cricketsAppeared.FadingParticleSystem();
        Mute();
    }

    private void CricketsAppeared()
    {
        cricketsAppeared.EnablingParticleSystem();
    }

    private void AppearanceCreatures()
    {
        int amountMonster = UnityEngine.Random.Range(minAmountMonster, maxAmountMonster);

        for (int i = 0; i <= amountMonster; i++)
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

        Vector3 randomPosition = new Vector3(
            UnityEngine.Random.Range(areaCenter.x - areaSize.x / 2, areaCenter.x + areaSize.x / 2),
            UnityEngine.Random.Range(areaCenter.y - areaSize.y / 2, areaCenter.y + areaSize.y / 2),
            areaCenter.z
        );

        return randomPosition;
    }

    private void Unmute()
    {
        for (int i = 0; i < soundClips.Length; i++)
        {
            SoundManager.Instance.PlaySound(soundClips[i]);
        }
    }

    private void Mute()
    {
        for (int i = 0; i < soundClips.Length; i++)
        {
            SoundManager.Instance.FadeSound(soundClips[i]);
        }
    }

}
