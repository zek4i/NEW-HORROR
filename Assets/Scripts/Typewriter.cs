using System.Collections;
using UnityEngine;
using TMPro;

public class Typewriter : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpProText; // Reference to TMP_Text component
    [SerializeField] private float timeBetweenChars = 0.05f; // Time delay between each character
    private Coroutine typingCoroutine; // Reference to active coroutine

    /// <summary>
    /// Starts the typewriter effect with the given text.
    /// </summary>
    /// <param name="textToType">Text to type out.</param>
    public void StartTyping(string textToType)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // Stop any ongoing typing effect
        }
        typingCoroutine = StartCoroutine(TypeText(textToType)); // Start the typing effect
    }

    /// <summary>
    /// Clears the text and stops any ongoing typing coroutine.
    /// </summary>
    public void ClearText()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        tmpProText.text = ""; // Clear the text
    }

    private IEnumerator TypeText(string textToType)
    {
        tmpProText.text = ""; // Clear the current text

        foreach (char c in textToType)
        {
            tmpProText.text += c; // Add the next character
            yield return new WaitForSeconds(timeBetweenChars); // Wait before adding the next character
        }
        typingCoroutine = null; // Typing complete
    }
}
