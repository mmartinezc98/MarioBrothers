using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public string sceneToLoad = "Level1_1";
    

    
    public void LoadLevel()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene("Level1_1");
    }
}




