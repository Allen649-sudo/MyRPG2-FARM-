using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using KnightAdventure.Utils;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float distanceMin = 3f;
    [SerializeField] private float distanceMax = 7f;
    [SerializeField] private float timerMin = 1f;
    [SerializeField] private float timerMax = 5f;

    private State state;
    [SerializeField] private State startingState;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    CreaturesAnimation creaturesAnimation;
    DataCreatures dataCreatures;
    public CreaturesShooting creaturesShooting;
    private float roamingTime;
    [SerializeField] private float stoppingDistance = 2.1f;

    private Vector3 roamingPos;
    private Vector3 startingPosition;

    private Vector2 lastMoveDirection;
    private Vector2 lastAttack;

    private GameObject playerObj;
    GameObject player;
    bool tryWasShot = true;

    private enum State
    {
        Idle,
        Roaming,
        Chase,
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
        creaturesAnimation = GetComponent<CreaturesAnimation>();
        dataCreatures = GetComponent<DataCreatures>();
        startingPosition = transform.position;
    }

    void Update()
    {
        roamingTime -= Time.deltaTime;
        Animate();
        switch (state)
        {
            case State.Idle:
                if (roamingTime < 0)
                {
                    StartRoaming();
                }
                break;

            case State.Roaming:
                if (navMeshAgent.remainingDistance < 0.1f) 
                {
                    state = State.Idle;
                    navMeshAgent.speed = 1f;

                    roamingTime = Random.Range(timerMin, timerMax); 
                }
                break;

            case State.Chase:
                if (Vector3.Distance(transform.position, playerObj.transform.position) > stoppingDistance)
                {
                    creaturesAnimation.AnimDeactiveAttack();

                    navMeshAgent.isStopped = false;
                    navMeshAgent.speed = 2.4f;
                    SettingPath(playerObj.transform.position, transform.position, playerObj.transform.position);
                }
                else
                {
                    creaturesAnimation.AnimAttack();
                    navMeshAgent.isStopped = true;
                    
                    if (dataCreatures.creaturesSO.shooter == true && creaturesShooting != null)
                    {
                        if (tryWasShot)
                        {

                            creaturesShooting.GetComponent<CreaturesShooting>().SavingPlayerPos(playerObj);
                            tryWasShot = false;
                        }
                    }
                }
                break;

        }
    }

    private void StartRoaming()
    {
        Roaming();
        state = State.Roaming; 
    }

    public void ChasePlayer(GameObject playerObject)
    {
        state = State.Chase;
        playerObj = playerObject;
    }

    private void Roaming()
    {
        startingPosition = transform.position;
        roamingPos = GetRoamingPosition();
        roamingTime = timerMax;
        SettingPath(roamingPos, startingPosition, roamingPos);
    }

    void SettingPath(Vector3 patn, Vector3 sourcePosition, Vector3 targetPosition)
    {
        navMeshAgent.SetDestination(patn);
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + KnightUtils.GetRandomDir() * UnityEngine.Random.Range(distanceMin, distanceMax);
    }

    void Animate()
    {
        Vector3 currentPosition = transform.position;

        Vector3 moveDirection = currentPosition - roamingPos;
        moveDirection = navMeshAgent.velocity;

        roamingPos = currentPosition;
        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDirection = moveDirection;
            lastAttack = moveDirection;
        }

        creaturesAnimation.Animation(moveDirection, lastMoveDirection, lastAttack);
    }
}
