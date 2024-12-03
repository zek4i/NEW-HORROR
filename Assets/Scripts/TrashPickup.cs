using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    public string trashName = "Trash";
    private bool isInRange = false; // Detect when the player is near the trash

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Assuming player has "Player" tag
        {
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    // Method to pick up the trash
    public void PickupTrash()
    {
        if (isInRange)
        {
            Debug.Log("Destroying: " + gameObject.name);
            Debug.Log("Trash picked up: " + trashName);
            Destroy(gameObject);  // Remove trash from the scene
        }
    }
}
