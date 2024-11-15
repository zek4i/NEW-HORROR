using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; //we dont want to reference this
    public FirstPersonController firstPersonController;



    public GameObject PauseMenuUI; //what are we pausing

    private void Start()
    {
        // Get the MouseLook script from the FPS controller
      
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        // Enable mouse look
        firstPersonController.m_MouseLook.SetCursorLock(true); // Re-lock cursor
        firstPersonController.enabled = true;                 // Re-enable FPS controller
    }    
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        // Disable mouse look
        firstPersonController.m_MouseLook.SetCursorLock(false); // Unlock cursor
        firstPersonController.enabled = false;                 // Disable FPS controller
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        //load menu scene
        Debug.Log("loading menu hehehehehe");
    }
    public void QuitGame()
    {
        Debug.Log("quitting game hehhheheheh");
        Application.Quit();
    }
}
