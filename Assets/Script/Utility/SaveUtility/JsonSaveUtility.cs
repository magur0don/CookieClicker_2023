using System.IO;
using UnityEngine;

public class JsonSaveUtility 
{
    public static string saveFilePath = $"{Application.persistentDataPath}/SaveData.json";

    public static void Save<T>(T data) where T : class
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }

    public static T Load<T>() where T : class
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<T>(json);
        }
        else
        {
            Debug.LogWarning($"File not found: {saveFilePath}");
            return null;
        }
    }
}
