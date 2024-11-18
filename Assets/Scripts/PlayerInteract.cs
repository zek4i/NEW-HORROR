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
    [SerializeField] public FirstPersonController firstPersonController;

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

                    DisableMouse();

                }
            }

        }
      
    }

    private void DisableMouse()
    {
        firstPersonController.m_MouseLook.SetCursorLock(false); // Unlock cursor
        firstPersonController.enabled = false;                 // Disable FPS controller
    }
    private void EnableMouse()
    {
        firstPersonController.m_MouseLook.SetCursorLock(true); // Unlock cursor
        firstPersonController.enabled = true;                 // Disable FPS controller
    }
}