using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDetectionAndCauseDamage : MonoBehaviour
{
    DataCreatures dataCreatures;
    LayerMask targetLayer;
    MovementEnemy movementEnemy;
    private GameObject playerObj;
    private bool playerClose;

    void Start()
    {
        dataCreatures = GetComponent<DataCreatures>();
        movementEnemy = GetComponent<MovementEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;

        if (layer == LayerMask.NameToLayer("Player"))
        {
            playerObj = collider.gameObject;
            playerClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;

        if (layer == LayerMask.NameToLayer("Player"))
        {
            playerClose = false;
        }
    }

    void Update()
    {
        if (playerObj != null)
        {
            FollowPlayer(playerObj);
        }
    }

    private void FollowPlayer(GameObject playerPos)
    {
         movementEnemy.ChasePlayer(playerPos);
    }

    public void CauseDamage()
    {
        if (playerClose)
        {
            playerObj.GetComponent< GettingWoundPlayer>().GetInjury();
        }
        else if (dataCreatures.creaturesSO.shooter)
        {
            playerObj.GetComponent<GettingWoundPlayer>().GetInjury();
        }
    }

    public void TryPlayerTransform(GameObject playerObject)
    {
        playerObj = playerObject;
    }
}
