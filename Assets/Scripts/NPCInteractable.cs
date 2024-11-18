using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public string interactionMessage = "Hello, Player!";
    public void Interact()
    {
        Debug.Log(interactionMessage);

    }
}
