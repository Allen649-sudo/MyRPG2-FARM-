using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenBed : MonoBehaviour
{
    [SerializeField] private ScriptableObjectSO[] scriptableObjectSO;
    private SpriteRenderer spriteRenderer;

    private bool ready = false;
    private bool growing = true;
    private bool start = true;

    [SerializeField] private Sprite emptySprite;
    ScriptableObjectSO temporaryScriptableObjectSOPlayerHand;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (start)
        {
            ScriptableObjectSO scriptableObjectSOPlayerHand = PlayerHand.Instance.scriptableObjectSO;
            temporaryScriptableObjectSOPlayerHand = scriptableObjectSOPlayerHand;

            foreach (ScriptableObjectSO scriptableObjectSOGarden in scriptableObjectSO)
            {
                if (PlayerHand.Instance.scriptableObjectSO == scriptableObjectSOGarden && growing)
                {
                    StartCoroutine(BeginGrowth(PlayerHand.Instance.scriptableObjectSO));
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

    private IEnumerator BeginGrowth(ScriptableObjectSO scriptableObjectSO)
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
