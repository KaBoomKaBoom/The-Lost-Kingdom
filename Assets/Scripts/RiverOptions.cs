using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RiverOption : MonoBehaviour
{
	// Method for Button 1
	public void OnButton1Click()
	{
		Debug.Log("Button 1 clicked!");
		SaveManager.Save(7, 9, 5);
		SceneManager.LoadScene("UpRiver"); // Load Scene1
	}

	// Method for Button 2
	public void OnButton2Click()
	{
		Debug.Log("Button 2 clicked!");
		SaveManager.Save(4, 7, 6);
		SceneManager.LoadScene("DownRiver"); // Load Scene2
	}

	public void OnButtonClick() 
	{
		SaveManager.Save(4, 6, 3);
	}
}

