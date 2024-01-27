using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    // The UI text element to display the dialogue
    public TextMeshPro dialogueText;

    public RunStateManager runStateManager;
    // The array of dialogue lines
    public string[] dialogueLines;

    // The index of the current dialogue line
    private int currentLine;

    // The speed of the typewriter effect in seconds per character
    public float typingSpeed = 0.05f;

    // The audio source to play the typewriter sound effect
    public AudioSource typingSound;

    // The boolean to check if the dialogue is typing
    private bool isTyping;

    public GameObject ButtonCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // Start the dialogue by displaying the first line
        currentLine = 0;
        StartCoroutine(TypeLine(dialogueLines[currentLine]));
    }

    // Update is called once per frame
    void Update()
    {
        // If the user presses the space key and the dialogue is not typing
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            // If there are more dialogue lines to display
            if (currentLine < dialogueLines.Length - 1)
            {
                // Increment the current line index and display the next line
                currentLine++;
                StartCoroutine(TypeLine(dialogueLines[currentLine]));
            }
            else
            {
                // End the dialogue by clearing the text
                // dialogueText.text = "";

                //prompt the selection

                ButtonCanvas.SetActive(true);
            }
        }
    }

    public void Response(string response)
    {
        ButtonCanvas.SetActive(false);
        StartCoroutine(TypeLineEnd(response));
    }

    // The coroutine to display the dialogue line with the typewriter effect
    IEnumerator TypeLineEnd(string response)
    {
        // Set the isTyping flag to true
        isTyping = true;

        // Clear the previous text
        dialogueText.text = "";

        // Loop through each character in the dialogue line
        foreach (char c in response.ToCharArray())
        {
            // Add the character to the text element
            dialogueText.text += c;

            // Play the typing sound effect
            // typingSound.Play();

            // Wait for the typing speed duration
            yield return new WaitForSeconds(typingSpeed);
        }

        // Set the isTyping flag to false
        isTyping = false;

        runStateManager.ChangeState(new ChaseEarth(runStateManager));
        
    }




// The coroutine to display the dialogue line with the typewriter effect
IEnumerator TypeLine(string response)
    {
        // Set the isTyping flag to true
        isTyping = true;

        // Clear the previous text
        dialogueText.text = "";

        // Loop through each character in the dialogue line
        foreach (char c in response.ToCharArray())
        {
            // Add the character to the text element
            dialogueText.text += c;

            // Play the typing sound effect
            // typingSound.Play();

            // Wait for the typing speed duration
            yield return new WaitForSeconds(typingSpeed);
        }

        // Set the isTyping flag to false
        isTyping = false;
    }
}
