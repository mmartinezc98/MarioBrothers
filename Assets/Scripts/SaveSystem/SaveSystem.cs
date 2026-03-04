using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private static string FilePath => Path.Combine(Application.persistentDataPath, "savegame.json");

    public static void Save(int score)
    {
        SaveData data = new SaveData();
        data.score = score;
        data.date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(FilePath, json);

        Debug.Log("Partida guardada en: " + FilePath);
    }

    public static SaveData Load()
    {
        if (!File.Exists(FilePath))
        {
            Debug.Log("No hay archivo de guardado.");
            return null;
        }

        string json = File.ReadAllText(FilePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        return data;
    }

}
