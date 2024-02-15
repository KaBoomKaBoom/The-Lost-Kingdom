using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class SaveManager : MonoBehaviour
{
	public static void SaveGame(GameData data)
	{
		string json = JsonUtility.ToJson(data);
		File.WriteAllText(@"Assets\save.json", json);
	}

	public static GameData LoadGame()
	{
		string path = @"Assets\save.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);

			return JsonUtility.FromJson<GameData>(json);
		}
		else
		{
			Debug.LogWarning("No save file found.");
			return null;
		}
	}
	public static void FirstSave(int a, int b, int c)
	{
		GameData data = new GameData();
		data.saveDate = System.DateTime.Now.ToString();
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
		data.saveDate = System.DateTime.Now.ToString();
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
		GameData data = SaveManager.LoadGame();
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
