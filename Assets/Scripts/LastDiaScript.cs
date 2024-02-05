using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastDiaScript : MonoBehaviour
{


	void Update()
	{
		// Check for spacebar input to trigger the conversation
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Load the Conversation scene when the spacebar is pressed
			SceneManager.LoadScene("LastDialogue");
		}
	}

}
