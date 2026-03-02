using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button mainMenuButton;

    private void Awake()
    {
        mainMenuButton = GetComponent<Button>();
        mainMenuButton.onClick.AddListener(LoadLevel);
    }

    public string sceneToLoad = "PantallaInicio";



        public void LoadLevel()
        {
            // Cargar la escena del juego
            SceneManager.LoadScene("PantallaInicio");
        }
    
}
