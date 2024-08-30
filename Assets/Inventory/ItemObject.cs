using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ScriptableObjectSO scriptableObjectSO;
    [SerializeField] private GameObject player;
    private Vector3 distanceFromPlayer;

    private bool playerReward = false;

    public float spawnDistance = 2f;

    public Animator animator;

    void Start()
    {
        scriptableObjectSO.prefab = gameObject;
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerReward = true;
    }

    public void Activate(Transform transformPos = null, Quaternion rotation = default)
    {
        if (transformPos == null)
        {
            if (player != null)
            {
                transformPos = player.transform;
            }
            gameObject.SetActive(true);
            distanceFromPlayer = new Vector3(1.2f, 0f, 0f);
            transform.position = transformPos.position + distanceFromPlayer; 
            
        }
        else
        {

            gameObject.SetActive(true);
            PosTransferredItem(transformPos);
            if (rotation != null)
            {
                transform.rotation = rotation;
            }
        }

    }

    void PosTransferredItem(Transform transformPos)
    {
        Vector3 distanceFromNotPlayer = new Vector3(1.2f, 0f, 0f);
        transform.position = transformPos.position + transformPos.up * -1;
    }

}
