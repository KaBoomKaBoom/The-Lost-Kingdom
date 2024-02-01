using UnityEngine;
using UnityEngine.SceneManagement;

public class ConversatioTrigger : MonoBehaviour
{
    void Update()
    {
        // Check for spacebar input to trigger the conversation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the Conversation scene when the spacebar is pressed
            SceneManager.LoadScene("Conversation");
        }
    }
}
