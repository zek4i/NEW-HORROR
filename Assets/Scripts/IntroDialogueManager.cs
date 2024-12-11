using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class IntroDialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText; // Reference to the TMP Text for dialogue
    [SerializeField] private CanvasGroup blackScreen; // Reference to the CanvasGroup of the black screen
    [SerializeField] private float fadeOutDuration = 2f; // Time for the fade-out effect
    [SerializeField] private float dialogueDuration = 5f; // Duration before fading out after dialogue starts
    [SerializeField] private Canvas Crosshair;

    private bool isDialogueActive = false;

    void Start()
    {
        Crosshair.gameObject.SetActive(false);
        // Start the dialogue and black screen fade-out sequence
        StartCoroutine(StartIntroSequence());
    }

    // Coroutine to handle the intro sequence (black screen + dialogue + fade out)
    private IEnumerator StartIntroSequence()
    {
        // Show the black screen initially
        blackScreen.alpha = 1f;

        // Wait for the dialogue to show up (could be replaced with your dialogue logic)
        yield return StartCoroutine(DisplayIntroDialogue());

        // Wait for the dialogue duration
        yield return new WaitForSeconds(dialogueDuration);

        dialogueText.gameObject.SetActive(false);

        // Start fading out the black screen
        yield return StartCoroutine(FadeOutBlackScreen());

        // Proceed to the game (you can load the next scene or enable gameplay elements)
        StartGame();
    }

    private IEnumerator DisplayIntroDialogue()
    {
        isDialogueActive = true;

        // Start typing out the dialogue
        string dialogue = "Every year, we make it a point to do something special for Halloween. This year, Eva came up with the idea to camp out in the woods for a Halloween-themed night. It sounded fun. Spooky stories, costumes, and a chance to scare each other senseless."; // Example dialogue
        dialogueText.text = ""; // Clear any existing text
        foreach (char letter in dialogue)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f); // Delay between each character
        }

        yield return null;
    }

    private IEnumerator FadeOutBlackScreen()
    {
        float timeElapsed = 0f;

        // Fade out the black screen by reducing its alpha
        while (timeElapsed < fadeOutDuration)
        {
            blackScreen.alpha = 1f - (timeElapsed / fadeOutDuration); // Lerp alpha to 0
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the black screen is completely faded out
        blackScreen.alpha = 0f;
    }

    private void StartGame()
    {
        // After the fade-out, proceed to the game (e.g., enable gameplay UI or load the next scene)
        Debug.Log("Start the game!");
        
    }   
}
