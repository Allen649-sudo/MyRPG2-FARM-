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

    void Start()
    {
        /*if (scriptableObjectSO is PackageObjectSO packageObjectSO)
        {
            packageObject = packageObjectSO;
        }*/
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (start)
        {
            ScriptableObjectSO scriptableObjectSOPlayerHand = PlayerHand.Instance.scriptableObjectSO;
            if (scriptableObjectSOPlayerHand is PackageObjectSO temporaryScriptableObjectPlayerHand)
            {
                temporaryScriptableObjectSOPlayerHand = temporaryScriptableObjectPlayerHand;
            }

            foreach (PackageObjectSO scriptableObjectSOGarden in scriptableObjectSO)
            {
                if (temporaryScriptableObjectSOPlayerHand == scriptableObjectSOGarden && growing)
                {
                    StartCoroutine(BeginGrowth(temporaryScriptableObjectSOPlayerHand));
                    scriptableObjectSOPlayerHand.prefab.GetComponent<PackageSeedDispenseCountScript>().DispenseSeeds();
                    Debug.Log("The seed is planted");
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

        yield return new WaitForSeconds(scriptableObjectSO.timeFirstStage);
        spriteRenderer.sprite = scriptableObjectSO.spriteFirstStage;

        yield return new WaitForSeconds(scriptableObjectSO.timeSecondtStage);
        spriteRenderer.sprite = scriptableObjectSO.spriteSecondtStage;

        yield return new WaitForSeconds(scriptableObjectSO.timeThirdStage);
        spriteRenderer.sprite = scriptableObjectSO.spriteThirdStage;

        yield return new WaitForSeconds(scriptableObjectSO.timeFourthStage);
        spriteRenderer.sprite = scriptableObjectSO.spriteFourthStage;


        ready = true;
    }
}
