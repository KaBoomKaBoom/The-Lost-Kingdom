using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainRiverScrip : MonoBehaviour
{
	public Text introText;
	public float revealSpeed = 0.1f;

	public GameObject backIntro;

	public GameObject button1;
	public GameObject button2;


	public bool full = false;

	public Text after;

	public AudioSource audio1, audio2;

	void Start()
	{
		audio1.Play();
		audio2.Stop();
		after.gameObject.SetActive(false);
		button1.SetActive(false);
		button2.SetActive(false);
		StartCoroutine(RevealText());
	}

	private void Update()
	{
		if (full)
		{
			after.gameObject.SetActive(true);
		}
		if (full && Input.GetKeyDown(KeyCode.Space))
		{
			after.gameObject.SetActive(false);
			introText.gameObject.SetActive(false);
			backIntro.SetActive(false);
			audio1.Stop();
			audio2.Play();
			button1.SetActive(true);
			button2.SetActive(true);
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
		full = true;
	}
}
