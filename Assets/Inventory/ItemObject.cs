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

    public void Activate(Transform transformPos = null)
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
        }

    }

    void PosTransferredItem(Transform transformPos)
    {

        Vector3 distanceFromNotPlayer = new Vector3(1.2f, 0f, 0f);
        transform.position = transformPos.position + transformPos.up * -1;
    }

    /*public Vector3 GetTransformSpawnItem()
    {
        Transform transformPos = player.transform;
        distanceFromPlayer = new Vector3(1.2f, 0f, 0f);
        Vector3 transform = transformPos.position + distanceFromPlayer;
        return transform;
    }

    public void InstantiateItem(ScriptableObjectSO scriptableObjectSO)
    {
        GameObject newItem = Instantiate(scriptableObjectSO.prefab, GetTransformSpawnItem(), Quaternion.identity);
    }*/

    /*public void AnimationReward()
    {
        if (animator != null)
        {
            animator.SetBool("Reward", true);
        }
    }*/
}
