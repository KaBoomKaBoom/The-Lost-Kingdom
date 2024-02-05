using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VillageIntro : MonoBehaviour
{
    public Text introText1;
    public Text introText2;
    public float revealSpeed = 0.1f;
    public bool full = false;

    public Text inIntro;
    public Text afterIntro;


    void Start()
    {
        introText2.gameObject.SetActive(false);
        inIntro.gameObject.SetActive(true);
        afterIntro.gameObject.SetActive(false);
        StartCoroutine(RevealText(introText1));
    }

    private void Update()
    {   
        if (full && Input.GetKeyDown(KeyCode.E)) 
        {
            full = false;
            introText1.gameObject.SetActive(false);
            introText2.gameObject.SetActive(true);
            StartCoroutine(RevealText(introText2));
            inIntro.gameObject.SetActive(false);
            afterIntro.gameObject.SetActive(true);
        }

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

