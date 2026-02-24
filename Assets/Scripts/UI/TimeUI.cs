using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    private TMP_Text timeText;
    private float timeRemaining = 400f; // tiempo estilo Mario

    private void Awake()
    {
        timeText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0)
            timeRemaining = 0;

        timeText.text = "" + Mathf.FloorToInt(timeRemaining);
    }
}

