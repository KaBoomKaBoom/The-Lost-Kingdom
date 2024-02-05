using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Crossroad : MonoBehaviour
{
    public Text introText;
    public GameObject playerIcon;
    public GameObject travelerIcon;

    public GameObject backIntro;
    public GameObject backPlayer;
    public GameObject backTraveler;

    public float revealSpeed = 0.1f;
    private bool textFullyRevealed = false;

    public Text playerDialogueText;
    public Text travelerDialogueText;

    public Text instroctionsInDialogue;
	public Text instroctionsAfterDialogue;

	public Button button1;
	public Button button2;
	public Button button3;

	private string[] playerLines = {
        "Yes, I find myself torn between these three paths. Each one seems fraught with danger, yet filled with promise. How am I to choose?",
        "Please, tell me — what lies ahead on each of these paths? What dangers must I face, and what rewards await me? ",
        "It is a difficult choice indeed. Each path presents its own challenges and rewards, yet only one can lead me closer to the lost kingdom I seek. ",
        "Thank you, traveler. I will heed your words and choose my path wisely. Whatever awaits me, I will face it with courage and resolve.",

    };

    private string[] travelerLines = {
        "Ah, young adventurer, it seems you have reached a crossroads in your journey—a moment of decision that will shape the path ahead.",
        "Indeed, the choices we make on our journey can often seem daunting, fraught with uncertainty and doubt. But fear not, for I am here to offer guidance to those who seek it.",
        "On the left lies the treacherous ascent. On the right flows the perilous river. And straight ahead lies an enigmatic tunnel.",
        "Remember, young adventurer, the path you choose is not just about the destination, but the journey itself. Trust in your instincts, and let the stars guide you on your quest. ",
    };

    private int currentLine = 0;
    private int playersReplics = 0;
    private int travelerReplics = 0;

    void Start()
    {
        playerIcon.SetActive(false);
        travelerIcon.SetActive(false);
        backPlayer.SetActive(false);
        backTraveler.SetActive(false);
        instroctionsInDialogue.gameObject.SetActive(false);
		instroctionsAfterDialogue.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
		StartCoroutine(RevealText());
    }

    void Update()
    {
		instroctionsInDialogue.gameObject.SetActive(true);
		// Check if the introductory text has been fully revealed and spacebar is pressed
		if (textFullyRevealed && Input.GetKeyDown(KeyCode.E))
        {
            // Hide the introductory text
            introText.gameObject.SetActive(false);
            backIntro.SetActive(false);
            // Show character icons
            playerIcon.SetActive(true);
            travelerIcon.SetActive(true);
            backPlayer.SetActive(true);
            backTraveler.SetActive(true);
            DisplayNextLine();
        }
        if (currentLine == 8)
        {
            instroctionsInDialogue.gameObject.SetActive(false);
            instroctionsAfterDialogue.gameObject.SetActive(true);
        }
		if (playersReplics == 4 && travelerReplics == 4 && Input.GetKeyDown(KeyCode.Space))
        {
            playerDialogueText.gameObject.SetActive(false);
            travelerDialogueText.gameObject.SetActive(false);
            travelerIcon.SetActive(false);
            backPlayer.SetActive(false);
            backTraveler.SetActive(false);
            button1.gameObject.SetActive(true);
			button2.gameObject.SetActive(true);
			button3.gameObject.SetActive(true);
		}
    }

    IEnumerator RevealText()
    {
        string originalText = introText.text; // Store the original text of introText

        introText.text = ""; // Clear the text initially

        // Loop through each character in the original text
        foreach (char c in originalText)
        {
            // Append the current character to the displayed text
            introText.text += c;

            // Wait for a short duration before displaying the next character
            yield return new WaitForSeconds(revealSpeed);
        }

        // Mark introductory text as fully revealed
        textFullyRevealed = true;
    }

    void DisplayNextLine()
    {
        // Check if there are still lines left to display
        if (currentLine < playerLines.Length + travelerLines.Length && playersReplics == travelerReplics)
        {
            // Display player's line
            travelerDialogueText.text = travelerLines[travelerReplics];
            travelerReplics++;
        }
        else if (currentLine < travelerLines.Length + playerLines.Length && travelerReplics > playersReplics)
        {
            // Display traveler's line
            playerDialogueText.text = playerLines[playersReplics];
            playersReplics++;
        }
        else
        {
            // Dialogue is complete, transition to next scene or return to main scene
            // For example, you can use SceneManager.LoadScene() to load the next scene
            Debug.Log("Dialogue complete!");
            return;
        }

        currentLine++;
    }
}
