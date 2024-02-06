using UnityEngine;
using UnityEngine.SceneManagement;

public class RiverOption : MonoBehaviour
{
	// Method for Button 1
	public void OnButton1Click()
	{
		Debug.Log("Button 1 clicked!");
		SceneManager.LoadScene("UpRiver"); // Load Scene1
	}

	// Method for Button 2
	public void OnButton2Click()
	{
		Debug.Log("Button 2 clicked!");
		SceneManager.LoadScene("DownRiver"); // Load Scene2
	}
}

