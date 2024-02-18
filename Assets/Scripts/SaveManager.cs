using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class SaveManager : MonoBehaviour
{
	public static void SaveGame(GameData data)
	{
		PlayerPrefs.SetString("SceneName", data.sceneName);
		PlayerPrefs.SetInt("Characteristic1", data.physicalStrength);
		PlayerPrefs.SetInt("Characteristic2", data.emotionalStrength);
		PlayerPrefs.SetInt("Characteristic3", data.knowledge);
		PlayerPrefs.Save();
	}

	public static GameData LoadGame()
	{
		if (PlayerPrefs.HasKey("SceneName"))
		{
			GameData data = new GameData();
			data.sceneName = PlayerPrefs.GetString("SceneName");
			data.physicalStrength = PlayerPrefs.GetInt("Characteristic1");
			data.emotionalStrength = PlayerPrefs.GetInt("Characteristic2");
			data.knowledge = PlayerPrefs.GetInt("Characteristic3");

			return data;
		}
		else
		{
			Debug.LogError("No saved player data found.");
			return null;
		}
	}
	public static void FirstSave(int a, int b, int c)
	{
		GameData data = new GameData();
		data.sceneName = "Village";
		// Set player characteristics
		data.physicalStrength =a;
		data.emotionalStrength = b;
		data.knowledge = c;
		SaveManager.SaveGame(data);
	}
	public static void Save(int a, int b, int c)
	{
		GameData data = new GameData();
		data.sceneName = SceneManager.GetActiveScene().name; ;
		// Set player characteristics
		data.physicalStrength += a;
		data.emotionalStrength += b;
		data.knowledge += c;
		SaveManager.SaveGame(data);
		Debug.Log("Saved");
	}
	public static string Load()
	{
		GameData data = LoadGame();
		if (data != null)
		{
			Debug.Log("Current scene: " + data.sceneName);
			return data.sceneName;
		}
		else
		{
			Debug.Log("No save file found.");
			return null;
		}
	}
}
