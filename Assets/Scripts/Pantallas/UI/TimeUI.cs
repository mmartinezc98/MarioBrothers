using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeUI : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    private float timeRemaining;

    private bool fastMusicStarted = false; // ← evita que se active varias veces

    private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        timeRemaining = Main.Player.TimeElapsed;

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

        // --- CAMBIO A MÚSICA RÁPIDA ---
        if (timeRemaining <= 100 && !fastMusicStarted)
        {
            fastMusicStarted = true;

            Main.AudManager.StopMusic();
            Main.AudManager.PlayMusic(Main.SoundLibrary.groundHurry);
        }

        timeText.text = "" + Mathf.FloorToInt(timeRemaining);
    }






}

