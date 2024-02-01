using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroTextController : MonoBehaviour
{
    public Text introText;
    public float revealSpeed = 0.1f;

    void Start()
    {
        StartCoroutine(RevealText());
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
    }
}
