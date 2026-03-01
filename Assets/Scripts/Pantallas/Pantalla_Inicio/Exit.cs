using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    private Button exitButton;

    private void Awake()
    {
        exitButton=GetComponent<Button>();
        exitButton.onClick.AddListener(ExitApp);
    }
    

    private void ExitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif


    }
}
