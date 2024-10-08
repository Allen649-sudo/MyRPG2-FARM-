using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public TextAsset inkJSON;
    private bool tryNearbyPlayer;
    public GameObject interactButton;

    void Start()
    {
        interactButton.SetActive(false);
    }

    void OnEnable()
    {
        InteractWithPlayer.OnInteractWithPlayer += StartDialogue;
    }

    void OnDisable()
    {
        InteractWithPlayer.OnInteractWithPlayer -= StartDialogue;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Player"))
        {
            if (interactButton != null)
            {
                interactButton.SetActive(true);
            }
            tryNearbyPlayer = true;
        }
        
    }

    void StartDialogue()
    {
        if (tryNearbyPlayer)
        {
            if (!DialogueManager.Instance.dialogueIsPlaying)
            {
                DialogueManager.Instance.EnterDialogueMode(inkJSON, gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        int layer = collider.gameObject.layer;

        if (layer == LayerMask.NameToLayer("Player"))
        {
            interactButton.SetActive(false);

            tryNearbyPlayer = false;

            DialogueManager.Instance.ExitFromDialogue();
        }
    }
}
