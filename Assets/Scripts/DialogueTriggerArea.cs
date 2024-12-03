using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerArea : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger; // Reference to the DialogueTrigger on the NPC or object.
    private bool hasTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player")) // Check if the player enters the trigger
        {
            dialogueTrigger.TriggerDialogue(); // Trigger the dialogue
            hasTriggered = true;
        }
    }
}
