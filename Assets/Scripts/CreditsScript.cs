using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CreditsScript : MonoBehaviour
{
	public Text introText1;
	public float revealSpeed = 0.1f;
	public bool full = false;



	void Start()
	{
		StartCoroutine(RevealText(introText1));
	}

	private void Update()
	{


	}

	IEnumerator RevealText(Text text)
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
		full = true;

	}
}
