using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using KnightAdventure.Utils;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float distanceMin = 3f;
    [SerializeField] private float distanceMax = 7f;
    [SerializeField] private float timerMax = 2f;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roamingPos;
    private Vector3 startingPosition;

    public Animator animator;

    private enum State
    {
        Idle,
        Roaming
    }

    void Awake()
    {
        roamingTime = 2f;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;
        state = startingState;
    }

    private void Start()
    {
        startingPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        roamingTime -= Time.deltaTime; // Уменьшаем время на каждом кадре

        switch (state)
        {
            case State.Idle:
                animator.SetBool("Idle", true);
                if (roamingTime < 0)
                {
                    StartRoaming();
                }
                break;

            case State.Roaming:
                animator.SetBool("Idle", false);
                if (navMeshAgent.remainingDistance < 0.1f) // Проверяем, достигли ли мы позиции
                {
                    state = State.Idle; // Если дошли до места, переключаем назад на Idle
                    roamingTime = timerMax; // Сброс времени для следующего блуждания
                }
                break;
        }
    }

    // Метод для начала блуждания
    private void StartRoaming()
    {
        Roaming();
        state = State.Roaming; // Переключаем состояние
    }

    private void Roaming()
    {
        startingPosition = transform.position;
        roamingPos = GetRoamingPosition();
        ChangeFacingDirection(startingPosition, roamingPos);
        navMeshAgent.SetDestination(roamingPos);
        roamingTime = timerMax; // Устанавливаем таймер для следующего блуждания
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + KnightUtils.GetRandomDir() * UnityEngine.Random.Range(distanceMin, distanceMax);
    }

    private void Animate()
    {
        animator.SetFloat("Horizontal", roamingPos.x);
        animator.SetFloat("Vertical", roamingPos.y);
    }

    private void ChangeFacingDirection(Vector3 sourcePosition, Vector3 targetPosition)
    {
        if (sourcePosition.x > targetPosition.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }
}
