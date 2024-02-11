using UnityEngine;
using UnityEngine.SceneManagement;

public class AscentOptions : MonoBehaviour
{
	// Method for Button 1
	public void OnButton1Click()
	{
		Debug.Log("Button 1 clicked!");
		SaveManager.Save(8, 6, 5);

		SceneManager.LoadScene("Ruins"); // Load Scene1
	}

	// Method for Button 2
	public void OnButton2Click()
	{
		Debug.Log("Button 2 clicked!");
		SaveManager.Save(7, 3, 5);

		SceneManager.LoadScene("NoInfo"); // Load Scene2
	}
	public void OnButtonClick() 
	{
		SaveManager.Save(6, 3, 3);

	}
}

