using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

interface IInteractable
{
    public void Interact();
}
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform interactorSource; // Source of the raycast (e.g., camera)
    [SerializeField] float interactRange = 5f;  // Range of interaction
    [SerializeField] TextMeshProUGUI interactText; // Text to display for interaction

    private IInteractable currentInteractable; // Track the current interactable object

    private void Start()
    {
        interactText.gameObject.SetActive(false); // Ensure the text is hidden initially
    }

    private void Update()
    {
        // Cast a ray from the interactor source forward
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            // Check if the object has the IInteractable interface
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                currentInteractable = interactObj; // Store the current interactable
                interactText.gameObject.SetActive(true); // Show the interaction text
                interactText.text = "Press E to Pick Up"; // Set the message

                // Handle interaction when E is pressed
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact();
                }
            }
            else
            {
                ClearInteractable();
            }
        }
        else
        {
            ClearInteractable();
        }
    }

    // Clear the interactable object and hide the text
    private void ClearInteractable()
    {
        if (currentInteractable != null)
        {
            currentInteractable = null;
            interactText.gameObject.SetActive(false); // Hide the text
        }
    }
}
