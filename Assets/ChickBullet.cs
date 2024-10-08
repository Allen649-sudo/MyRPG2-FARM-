using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickBullet : MonoBehaviour
{
    public MagicBlowEnemySO bullet;

    public float followTime = 2f;

    private float timer = 0f;
    private bool isFollowing = false;
    private Rigidbody2D rb;

    private GameObject playerObj;
    private Vector3 playerPos;

    GameObject currentMaster;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(GameObject master, GameObject playerObject)
    {
        currentMaster = master;
        playerObj = playerObject;
        playerPos = playerObj.transform.position;
        isFollowing = true;
        timer = 0f;

        transform.position = currentMaster.transform.position;
    }

    void Update()
    {
        if (isFollowing && currentMaster != null)
        {
            Shot();
        }
    }

    void Shot()
    {
        transform.rotation = currentMaster.transform.rotation;

        transform.position = Vector3.MoveTowards(transform.position, playerPos, bullet.speed * Time.deltaTime);

        StartCoroutine(DeactiveBulletCoroutine());
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Player"))
        {
            currentMaster.GetComponent<PlayerDetectionAndCauseDamage>().CauseDamage();
            DeactiveBullet();
        }
    }

    IEnumerator DeactiveBulletCoroutine()
    {
        yield return new WaitForSeconds(bullet.lifetime);

        DeactiveBullet();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    void DeactiveBullet()
    {
        gameObject.SetActive(false);
    }

    private void StopFollowing()
    {
        isFollowing = false;
    }
}
