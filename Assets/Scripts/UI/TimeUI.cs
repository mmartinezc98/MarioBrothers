using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeUI : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    private float timeRemaining; // tiempo estilo Mario


    private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        timeRemaining= Main.Player.TimeElapsed; //hacemos que el tiempo sea igual a la variable tiempo del player donde guardamos el tiempo que llevamos

        Main.CustomEvents.OnLevelChanged.AddListener(SetTimeForLevel);
    }

    private void SetTimeForLevel()
    {
        Main.Player.ChangeTime(timeRemaining);
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0)
            timeRemaining = 0;

        timeText.text = "" + Mathf.FloorToInt(timeRemaining);
    }



}

