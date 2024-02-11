using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class DownRiver : MonoBehaviour
{
    public Text introText1;
    public Text introText2;
    public Text introText3;


    public float revealSpeed = 0.1f;
    public bool full = false;
    public bool full1 = false;
    public bool full2 = false;
    public Text inIntro;
    public Text afterIntro;



    void Start()
    {
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
            //var nextText = textQueue.Dequeue();
            introText2.gameObject.SetActive(true);
            StartCoroutine(RevealText(introText2, 2));
        }
        if (full1 && Input.GetKeyDown(KeyCode.E))
        {
            introText2.gameObject.SetActive(false);
            //var nextText = textQueue.Dequeue();
            introText3.gameObject.SetActive(true);
            StartCoroutine(RevealText(introText3, 3));
            inIntro.gameObject.SetActive(false);
            afterIntro.gameObject.SetActive(true);
        }
        if (full2 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("2DaysRoad");
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
	public void OnButtonClick()
	{

		SaveManager.Save(4, 7, 6);
	}
}
