using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NoTunnelScript : MonoBehaviour
{
	public Text introText1;
	public Text introText2;
	public Text introText3;
	public GameObject backIntro;

	public GameObject travelerIcon;
	public Text playerDialogueText;
	public Text travelerDialogueText;
	public GameObject backPlayer;
	private string[] playerLines = {
		"It has been... enlightening, to say the least. But I find myself uncertain of the path ahead. Did I make the right choice in turning back?",
		"So, what does that mean for me? Have I made a mistake in turning back, or was it the right decision after all? ",
		"I see... So, no matter which path I choose, will it ultimately shape the person I become? "

	};

	private string[] travelerLines = {
		"Ah, it seems our paths have crossed once more, young adventurer. Tell me, how fares your journey through the Enigmatic Tunnel?",
		"Every choice we make in life has consequences, young adventurer. Some lead us down new paths filled with adventure and discovery, while others may bring us face-to-face with challenges and hardships we never imagined. ",
		"That is a question only you can answer, my friend. Each decision we make shapes the course of our journey, leading us down paths both familiar and unknown. But remember, it is not the destination that defines us, but the journey itself. ",
		"Precisely. Whether you choose to continue down the Enigmatic Tunnel or explore another path entirely, know that each decision you make will change something in your life. Embrace the journey, young adventurer, and let it led you to new horizons and endless possibilities. "
	};

	private int currentLine = 0;
	private int playersReplics = 0;
	private int travelerReplics = 0;



	public float revealSpeed = 0.1f;
	public bool full = false;
	public bool full1 = false;
	public bool full2 = false;
	public Text inIntro;
	public Text afterIntro;



	void Start()
	{
		backPlayer.SetActive(false);
		travelerIcon.SetActive(false);
		introText2.gameObject.SetActive(false);
		introText3.gameObject.SetActive(false);
		inIntro.gameObject.SetActive(true);
		afterIntro.gameObject.SetActive(false);
		StartCoroutine(RevealText(introText1, 1));
	}

	private void Update()
	{
		if (full && Input.GetKeyDown(KeyCode.E))
		{
			full = false;
			introText1.gameObject.SetActive(false);
			introText2.gameObject.SetActive(true);
			StartCoroutine(RevealText(introText2, 2));
		}
		if (full1 && Input.GetKeyDown(KeyCode.E))
		{
			introText2.gameObject.SetActive(false);
			backIntro.gameObject.SetActive(false);
			backPlayer.SetActive(true);
			travelerIcon.SetActive(true);
			DisplayNextLine();
		}
		if (currentLine == playerLines.Length + travelerLines.Length)
		{
			inIntro.gameObject.SetActive(false);
			afterIntro.gameObject.SetActive(true);
		}
		if (currentLine == playerLines.Length + travelerLines.Length && Input.GetKeyDown(KeyCode.Space))
		{
			backPlayer.SetActive(false);
			travelerIcon.SetActive(false);
			backIntro.SetActive(true);
			introText3.gameObject.SetActive(true);
			StartCoroutine(RevealText(introText3, 3));
			inIntro.gameObject.SetActive(false);
			afterIntro.gameObject.SetActive(true);

		}
		if (full2 && Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene("Crossroads");
		}

	}

	IEnumerator RevealText(Text text, int n)
	{
		string originalText = text.text; // Store the original text of introText

		text.text = ""; // Clear the text initially

		// Loop through each character in the original text
		foreach (char c in originalText)
		{
			// Append the current character to the displayed text
			text.text += c;

			// Wait for a short duration before displaying the next character
			yield return new WaitForSeconds(revealSpeed);
		}

		if (n == 1) full = true;
		else if (n == 2) full1 = true;
		else full2 = true;
	}

	void DisplayNextLine()
	{
		// Check if there are still lines left to display
		if (currentLine < playerLines.Length + travelerLines.Length && playersReplics == travelerReplics)
		{
			playerDialogueText.gameObject.SetActive(false);
			travelerDialogueText.gameObject.SetActive(true);
			travelerDialogueText.text = travelerLines[travelerReplics];
			travelerReplics++;
		}
		else if (currentLine < travelerLines.Length + playerLines.Length && travelerReplics > playersReplics)
		{
			travelerDialogueText.gameObject.SetActive(false);
			playerDialogueText.gameObject.SetActive(true);
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
	public void OnButtonClick()
	{
		SaveManager.Save(2, 3, 2);
	}
}


