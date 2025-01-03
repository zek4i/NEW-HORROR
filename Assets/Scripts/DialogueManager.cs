using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//make a feature later (if necessary) where the previous dialogue is finished when 2 dialogues are tirggered at the same time only then the next dialogue is played
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Typewriter typewriter; // Reference to the Typewriter script
    [SerializeField] private Image nameBackground; 
    [SerializeField] private Image dialogueBackground; 

    private Queue<string> sentences; //fifo best for dialogues
    private bool isDialogueActive = false;
    void Start()
    {
        sentences = new Queue<string>();

        nameText.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);

        DialogueBGDisable();
    }

    private void DialogueBGDisable()
    {
        if (nameBackground != null)
        {
            nameBackground.gameObject.SetActive(false);
        }

        if (dialogueBackground != null)
        {
            dialogueBackground.gameObject.SetActive(false);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);

        DialogueBGEnable();

        nameText.text = dialogue.name; //comes in place of debug statement

        sentences.Clear(); //clear any existing sentences

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); //putting in the sentence we are currently looking at
        }
        isDialogueActive = true; // Set the dialogue flag
        DisplayNextSentence();
    }

    private void DialogueBGEnable()
    {
        if (nameBackground != null)
        {
            nameBackground.gameObject.SetActive(true);
        }

        if (dialogueBackground != null)
        {
            dialogueBackground.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (isDialogueActive && Input.GetMouseButtonDown(0)) // Listen for E key
        {
            DisplayNextSentence();
        }
    }
    public void DisplayNextSentence() //calling from the box collider which is triggering the convo
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        typewriter.StartTyping(sentence);
    }
    void EndDialogue()
    {
        Debug.Log("end of convo");
        isDialogueActive = false;

        nameText.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);

        DialogueBGDisable();
    }
}
