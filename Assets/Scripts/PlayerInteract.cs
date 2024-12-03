using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactableDistance = 3f;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private void Update()
    {
        RaycastHit hit; //raycast from the center of the camera and checks if there is anything within interactable dist
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactableDistance))
        {
            TrashPickup trash = hit.collider.GetComponent<TrashPickup>(); //check if it has trash pick up script
            Debug.Log("yes i can see the trash");
            if (trash != null)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    trash.PickupTrash();  // Call the method to pick up the trash
                    Debug.Log("yes i can pickup the trash");
                }
            }
        }
    }
}
