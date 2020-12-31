using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	public static void SaveGameController(GameController gameController)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		String path = Application.persistentDataPath + "/gameControllerData.hax";
		FileStream stream = new FileStream(path, FileMode.Create);

		GameControllerData data = new GameControllerData(gameController);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static GameControllerData loadGameController()
	{
		String path = Application.persistentDataPath + "/gameControllerData.hax";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			GameControllerData data = formatter.Deserialize(stream) as GameControllerData;
			stream.Close();
			
			return data;
		}
		else
		{
			Debug.LogError("Save file not found in " + path);
			return null;
		}
	}
}
