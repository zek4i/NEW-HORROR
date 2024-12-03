using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CollectTrash();
    }
    private void CollectTrash()
    {
        Debug.Log("Trash collected!"); // Print confirmation to the console
        Destroy(gameObject); // Destroy the trash object
    }
}
   
