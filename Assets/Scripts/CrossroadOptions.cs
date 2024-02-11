using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossroadOptions : MonoBehaviour
{
	// Method for Button 1
	public void OnButton1Click()
	{
		Debug.Log("Button 1 clicked!");
		SaveManager.Save(6, 3, 3);
		SceneManager.LoadScene("Ascent"); // Load Scene1
	}

	// Method for Button 2
	public void OnButton2Click()
	{
		SaveManager.Save(4, 6, 3);
		Debug.Log("Button 2 clicked!");
		SceneManager.LoadScene("River"); // Load Scene2
	}

	// Method for Button 3
	public void OnButton3Click()
	{
		SaveManager.Save(2, 4, 5);
		Debug.Log("Button 3 clicked!");
		SceneManager.LoadScene("Tunell"); // Load Scene3
	}
	public void onButtonClick()
	{
		SaveManager.Save(1, 1, 1);
	}

}
