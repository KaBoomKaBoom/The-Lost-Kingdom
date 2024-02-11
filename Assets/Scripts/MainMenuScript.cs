using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
	public void OnNewGameClick()
	{
		SceneManager.LoadScene("Village");
		SaveManager.FirstSave(1,1,1);
	}
	public void OnContinueClick()
	{
		SceneManager.LoadScene(SaveManager.Load());
	}


}
