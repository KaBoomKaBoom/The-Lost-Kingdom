using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text playerDialogueText;
    public Text travelerDialogueText;

    private string[] playerLines = {
        "Excuse me, traveler. I couldn't help but overhear your tales of the lost kingdom. Are they true? Is there truly a realm hidden away, waiting to be discovered?",
        "But why has it remained hidden for so long? If it holds such wealth and power, why has no one found it before?",
        "And yet, you seem so certain of its existence. What makes you believe in this lost kingdom?",
        "I see... But tell me, what dangers await those who dare to venture into the wilderness in search of this lost kingdom?",
        " I understand. Thank you for your guidance, traveler. I will heed your words and tread cautiously on this journey into the unknown."

    };

    private string[] travelerLines = {
        "Ah, young adventurer, the stories I tell are not mere fables spun from the threads of imagination. They are echoes of a forgotten time, whispers carried on the winds of destiny. The lost kingdom exists, of that I have no doubt.",
        "The path to the lost kingdom is not an easy one, my friend. It is shrouded in mystery and guarded by the elements themselves. Many have ventured forth in search of its treasures, but few have returned, and those who have speak only in hushed tones of the trials they faced. ",
        "Ah, that is a question only a true seeker of knowledge would ask. I believe because I have seen the signs, felt the whispers of the ancient stones beneath my feet. The world is full of wonders, young adventurer, if only we have the courage to seek them out. ",
        "The path is fraught with peril, my friend. From treacherous mountain passes to dark forests teeming with unknown creatures, the journey will test your strength and resolve. But it is not only the physical dangers you must beware of; there are those who would seek to deceive you, to lead you astray from the true path. ",
        "Remember, young adventurer, fortune favors the bold. But tread carefully, for the road ahead is long and full of twists and turns. May the stars guide you on your quest, and may you find what you seek in the depths of \"The Lost Kingdom."
    };

    private int currentLine = 0;
    private int playersReplics = 0;
    private int travelerReplics = 0;

    void Start()
    {
        DisplayNextLine();
    }

    void Update()
    {
        // Check for player input to advance the dialogue
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }

    void DisplayNextLine()
    {
        // Check if there are still lines left to display
        if (currentLine < playerLines.Length + 5 && playersReplics==travelerReplics)
        {
            // Display player's line
            playerDialogueText.text = playerLines[playersReplics];
            playersReplics++;
        }
        else if (currentLine < travelerLines.Length + 5 && travelerReplics<playersReplics)
        {
            // Display traveler's line
            travelerDialogueText.text = travelerLines[travelerReplics];
            travelerReplics++;
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
