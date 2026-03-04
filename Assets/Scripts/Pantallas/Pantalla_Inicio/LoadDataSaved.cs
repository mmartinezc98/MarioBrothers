using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LoadDataSaved : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI dateText;

    private void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "savegame.json");

        if (!File.Exists(path))
        {
            scoreText.text = "No hay partida guardada";
            dateText.text = "";
            return;
        }

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        scoreText.text = "Puntuación: " + data.score;
        dateText.text = "Fecha: " + data.date;
    }
}


