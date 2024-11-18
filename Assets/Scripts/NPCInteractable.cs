using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] public FirstPersonController firstPersonController;
    public string interactionMessage = "Hello, Player!";
    public void Interact()
    {
        DisableMouse();

    }

    public void StopInteracting()
    {
        EnableMouse();
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
