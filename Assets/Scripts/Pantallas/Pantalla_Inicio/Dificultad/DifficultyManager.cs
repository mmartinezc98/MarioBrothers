using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private int difficultCheck;
    private Button difficultyButton;

    private void Awake()
    {
        difficultyButton= GetComponent<Button>();
        difficultyButton.onClick.AddListener(SetDifficultyLives);

    }

    public void SetDifficultyLives()
    {
        Main.Player.SetDifficulty(difficultCheck);
        Debug.Log(Main.Player.Lives);
    }
}
