using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField]private Button resumeButton;

    private void Awake()
    {
        resumeButton = GetComponent<Button>();
        resumeButton.onClick.AddListener(ResumeLevel);
    }
    
    public void ResumeLevel()
    {
    
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);

        // Volvemos al mapa Player
        InputManager2.SwitchMap(InputManager2.InputSystemActions.Player);
    }
}
