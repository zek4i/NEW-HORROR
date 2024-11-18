using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DialogueEditor;
using Unity.VisualScripting;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;

    private bool isInteracting = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //basic logic for the npc to be detected by the player
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcinteractable))
                {
                    ConversationManager.Instance.StartConversation(myConversation); //actual action of that happens

                    npcinteractable.Interact();
                    isInteracting = true; // Mark as interacting
                    return; // Exit the loop after interacting


                }

            }

        }
       if (isInteracting && Input.GetKeyDown(KeyCode.Escape)) // Press Escape or a specific key to end
    {
        ConversationManager.Instance.EndConversation(); // End the conversation
        isInteracting = false; // Reset interaction state
    }

    }
    
}