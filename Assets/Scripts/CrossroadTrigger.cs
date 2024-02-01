using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossroadTrigger : MonoBehaviour
{
    void Update()
    {
        // Check for spacebar input to trigger the conversation
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Load the Conversation scene when the spacebar is pressed
            SceneManager.LoadScene("Crossroads");
        }
    }
}
