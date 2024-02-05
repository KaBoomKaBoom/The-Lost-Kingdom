using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossroadOptions : MonoBehaviour
{
	// Method for Button 1
	public void OnButton1Click()
	{
		Debug.Log("Button 1 clicked!");
		SceneManager.LoadScene("Ascent"); // Load Scene1
	}

	// Method for Button 2
	public void OnButton2Click()
	{
		Debug.Log("Button 2 clicked!");
		SceneManager.LoadScene("River"); // Load Scene2
	}

	// Method for Button 3
	public void OnButton3Click()
	{
		Debug.Log("Button 3 clicked!");
		SceneManager.LoadScene("Tunell"); // Load Scene3
	}
}
