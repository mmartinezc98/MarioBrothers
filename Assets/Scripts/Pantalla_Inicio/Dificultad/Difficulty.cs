using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button diffButton;
    [SerializeField] public GameObject difficultyMenu;
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject firstButtonmainMenu;
    [SerializeField] public GameObject firstButtonDiff;

    private void Awake()
    {
        diffButton = GetComponent<Button>();
        diffButton.onClick.AddListener(ManageDifficultyMenu);
    }
    private void Start()
    {
        InputManager2.InputSystemActions.UI.Atras.started +=ManageDiffButtons;
    }

    public void ManageDifficultyMenu()
    {
       

        if (!difficultyMenu.activeSelf) {

            difficultyMenu.SetActive(true);
            mainMenu.SetActive(false);

            EventSystem.current.SetSelectedGameObject(firstButtonDiff.gameObject);

        }
        else
        {
            difficultyMenu.SetActive(false);
            mainMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(firstButtonmainMenu.gameObject);

        }

    }

    public void ManageDiffButtons(InputAction.CallbackContext callback)
    {
        ManageDifficultyMenu();
    }

 

}
