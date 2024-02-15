using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class TunnelScript : MonoBehaviour
{
	public Text introText;
	public Text introText2;
	public float revealSpeed = 0.1f;

	public GameObject backIntro;

	public GameObject button1;
	public GameObject button2;


	public bool full1 = false;
	public bool full2 = false;

	public Text inIntro;

	public AudioSource audio1, audio2;
	void Start()
	{
		audio1.Play();
		audio2.Stop();
		inIntro.gameObject.SetActive(false);
		introText2.gameObject.SetActive(false);
		button1.SetActive(false);
		button2.SetActive(false);
		StartCoroutine(RevealText(introText,1));
	}

	private void Update()
	{
		if (full1)
		{
			inIntro.gameObject.SetActive(true);
		}
		if (full1 && Input.GetKeyDown(KeyCode.E))
		{
			full1 = false;
			introText.gameObject.SetActive(false);	
			introText2.gameObject.SetActive(true);
			StartCoroutine(RevealText(introText2, 2));
		}
		if (full2 && Input.GetKeyDown(KeyCode.E)) 
		{
			full2 = false; 
			introText2.gameObject.SetActive(false);
			inIntro.gameObject.SetActive(false);	
			backIntro.SetActive(false);
			audio1.Stop();
			audio2.Play();
			button1.SetActive(true);
			button2.SetActive(true);
		}
	}

	IEnumerator RevealText(Text introText, int n)
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
		if(n == 1) full1 = true;
		else if(n==2) full2 = true;
	}

	// Method for Button 1
	public void OnOption1Click()
	{
		Debug.Log("Button 1 clicked!");
		SaveManager.Save(4, 7, 8);
		SceneManager.LoadScene("InTunnel"); // Load Scene1
	}

	// Method for Button 2
	public void OnOption2Click()
	{
		Debug.Log("Button 2 clicked!");
		SaveManager.Save(2, 3, 2);
		SceneManager.LoadScene("NoTunnel"); // Load Scene2
	}
	public void OnOptionClick()
	{
		SaveManager.Save(2, 4, 5);
	}

}
