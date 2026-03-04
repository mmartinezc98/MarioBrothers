using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowSaveData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI dateText;

    private void Start()
    {
        var data = SaveSystem.Load();

        if (data == null)
        {
            scoreText.text = "Sin partida guardada";
            dateText.text = "----";
            return;
        }

        scoreText.text = data.score.ToString();
        dateText.text = data.date;
    }

}
