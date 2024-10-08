using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenBed : MonoBehaviour
{
    [SerializeField] private PackageObjectSO[] scriptableObjectSO;
    private SpriteRenderer spriteRenderer;

    private bool ready = false;
    private bool growing = true;
    private bool start = true;

    [SerializeField] private Sprite emptySprite;
    PackageObjectSO temporaryScriptableObjectSOPlayerHand;
    PackageObjectSO packageObject;
    GameObject itemPrefab;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (start)
        {
            itemPrefab = PlayerHand.Instance.itemPrefab;
            if (itemPrefab.GetComponent<ItemObject>().scriptableObjectSO is PackageObjectSO packageObjectSO)
            {
                temporaryScriptableObjectSOPlayerHand = packageObjectSO;
            }

            foreach (PackageObjectSO scriptableObjectSOGarden in scriptableObjectSO)
            {
                if (temporaryScriptableObjectSOPlayerHand != null)
                {
                    if (temporaryScriptableObjectSOPlayerHand == scriptableObjectSOGarden && growing)
                    {
                        StartCoroutine(BeginGrowth(temporaryScriptableObjectSOPlayerHand));
                        itemPrefab.GetComponent<PackageSeedDispenseCountScript>().DispenseSeeds();
                        Debug.Log("The seed is planted");
                    }
                }
            }
        }
        if (ready)
        {

            int randomInt = Random.Range(temporaryScriptableObjectSOPlayerHand.minFinishedItem, temporaryScriptableObjectSOPlayerHand.maxFinishedItem);
            ObjectPool.Instance.ActivateItem(randomInt, temporaryScriptableObjectSOPlayerHand.finishedItem, transform);
            spriteRenderer.sprite = emptySprite;
            ready = false;
            growing = true;
            start = true;
        }
    }

    private IEnumerator BeginGrowth(PackageObjectSO scriptableObjectSO)
    {
        growing = false;
        start = false;

        yield return new WaitForSeconds(temporaryScriptableObjectSOPlayerHand.timeFirstStage);
        spriteRenderer.sprite = temporaryScriptableObjectSOPlayerHand.spriteFirstStage;

        yield return new WaitForSeconds(temporaryScriptableObjectSOPlayerHand.timeSecondtStage);
        spriteRenderer.sprite = temporaryScriptableObjectSOPlayerHand.spriteSecondtStage;

        yield return new WaitForSeconds(temporaryScriptableObjectSOPlayerHand.timeThirdStage);
        spriteRenderer.sprite = temporaryScriptableObjectSOPlayerHand.spriteThirdStage;

        yield return new WaitForSeconds(temporaryScriptableObjectSOPlayerHand.timeFourthStage);
        spriteRenderer.sprite = temporaryScriptableObjectSOPlayerHand.spriteFourthStage;


        ready = true;
    }
}
