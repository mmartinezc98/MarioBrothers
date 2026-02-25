using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Difficulty : MonoBehaviour
{
    
    [SerializeField] public GameObject difficultyMenu;
    [SerializeField] public GameObject mainMenu;
    

    public void OpenDifficultyMenu()
    {
        difficultyMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

}
