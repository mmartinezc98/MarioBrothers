using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] private Button resumeButton;

    // Referencia al PauseScreen para llamar a su método Resume()
    [SerializeField] private PauseScreen pauseScreen;

    private void Awake()
    {
        resumeButton = GetComponent<Button>();
        resumeButton.onClick.AddListener(ResumeLevel);
    }

    public void ResumeLevel()
    {
        // Delegamos toda la lógica de reanudación al PauseScreen
        pauseScreen.Resume();
    }
}
