using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateLives : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;
    // Start is called before the first frame update

    private void Awake()
    {
        this.livesText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        this.livesText.text = Main.Player.Lives.ToString();
    }
}

  
