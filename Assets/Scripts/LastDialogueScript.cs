using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class LastDialogueScript : MonoBehaviour
{
	public Text introText;
	public GameObject playerIcon;
	public GameObject travelerIcon;

	public float revealSpeed = 0.1f;
	private bool textFullyRevealed = false;

	public Text playerDialogueText;
	public Text travelerDialogueText;

	public Text instroctionsInDialogue;
	public Text instroctionsAfterDialogue;


	private string[] playerLines = {
		"It has been quite the adventure, traveler. I've faced challenges and overcome obstacles, but I fear the true test still lies ahead.?",
		"But tell me, traveler, am I truly ready to see the lost kingdom? After all I've faced, do I have what it takes to uncover its mysteries? ",
		"I see... So, what must I do to prove myself worthy of seeing the lost kingdom? What challenges await me on the road ahead?  ",
		"Then I will continue this journey, traveler, wherever it may lead me. I will face whatever challenges come my way, and I will not rest until I uncover the secrets of the lost kingdom.",

	};

	private string[] travelerLines = {
		"Ah, it seems our paths have crossed once more, young adventurer. Tell me, how fares your journey? ",
		"Indeed, the road to the lost kingdom is fraught with peril and uncertainty, yet it is also filled with wonder and discovery for those who have the courage to seek it out. ",
		"That is a question only you can answer, young adventurer. The journey you have undertaken has tested your strength, your resilience, and your determination. But the true test lies not in what you have faced, but in what lies ahead. ",
		"The challenges that lie ahead are as varied as the stars in the sky, each one testing a different aspect of your character and resolve. But remember, young adventurer, it is not the destination that defines us, but the journey itself.",
	};

	private int currentLine = 0;
	private int playersReplics = 0;
	private int travelerReplics = 0;

	void Start()
	{
		playerIcon.SetActive(false);
		travelerIcon.SetActive(false);
		instroctionsInDialogue.gameObject.SetActive(false);
		instroctionsAfterDialogue.gameObject.SetActive(false);

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

			// Show character icons
			playerIcon.SetActive(true);
			travelerIcon.SetActive(true);
			DisplayNextLine();
		}
		if (currentLine == 8)
		{
			instroctionsInDialogue.gameObject.SetActive(false);
			instroctionsAfterDialogue.gameObject.SetActive(true);
		}
		if (playersReplics == 4 && travelerReplics == 4 && Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene("2DaysRoad");
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

