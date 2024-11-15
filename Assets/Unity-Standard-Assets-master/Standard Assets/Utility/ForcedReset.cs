using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class ForcedReset : MonoBehaviour
{
    public Image imageComponent; // Optional: Use if you need to display an image

    private void Update()
    {
        // Check if the reset button is pressed
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

