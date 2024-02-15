using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Ending : MonoBehaviour
{
    public Text introText;
    public Text introText2;
    public float revealSpeed = 0.1f;

    public GameObject backIntro;

    public bool full1 = false;
    public bool full2 = false;

    public Text inIntro;

    public string nextScene;
    void Start()
    {
        inIntro.gameObject.SetActive(false);
        introText2.gameObject.SetActive(false);
        StartCoroutine(RevealText(introText, 1));
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
            SceneManager.LoadScene(nextScene);
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
        if (n == 1) full1 = true;
        else if (n == 2) full2 = true;
    }
    }



