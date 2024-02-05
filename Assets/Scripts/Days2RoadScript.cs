using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Days2RoadScript : MonoBehaviour
{
	public Text roadText;
	public Text descrText;
	public Text instructionInText;
	public Text instruction;
	public float revealSpeed = 0.1f;
	private bool textFullyRevealed = false;


	void Start()
	{
		descrText.gameObject.SetActive(false);
		instruction.gameObject.SetActive(false);
		StartCoroutine(RevealText(roadText));
		instructionInText.gameObject.SetActive(true);
	}

	private void Update()
	{
		
		if (textFullyRevealed && Input.GetKeyDown(KeyCode.E)) 
		{
			textFullyRevealed = false;
			roadText.gameObject.SetActive(false);
			instructionInText.gameObject.SetActive(false);
			descrText.gameObject.SetActive(true);
			StartCoroutine(RevealText(descrText));
			instruction.gameObject.SetActive(true);
			
		}
		if (textFullyRevealed && Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene("TreasureChest");

		}
	}

	IEnumerator RevealText(Text text)
	{
		var originalText = text.text;
		text.text = ""; // Clear the text initially

		// Loop through each character in the original text
		foreach (char c in originalText)
		{
			// Append the current character to the displayed text
			text.text += c;

			// Wait for a short duration before displaying the next character
			yield return new WaitForSeconds(revealSpeed);
		}
		// Mark introductory text as fully revealed
		textFullyRevealed = true;

	}

}
