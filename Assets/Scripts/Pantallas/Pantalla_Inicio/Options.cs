using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    private Button optionsButton;
    [SerializeField] public GameObject optionsMenu;
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject firstButtonmainMenu;
    [SerializeField] public GameObject firstButtonOptions;

    private void Awake()
    {
        optionsButton = GetComponent<Button>();
        optionsButton.onClick.AddListener(ManageOptionsMenu);
    }
    private void Start()
    {
        InputManager2.InputSystemActions.UI.Atras.started +=ManageDiffButtons;
    }

    public void ManageDiffButtons(InputAction.CallbackContext callback)
    {
        ManageOptionsMenu();
    }

    public void ManageOptionsMenu() //para activar o desactivar el menu principal/menu de oopciones y seleccionar primer boton
    {       

        if (!optionsMenu.activeSelf) { 

            optionsMenu.SetActive(true);
            mainMenu.SetActive(false);

            EventSystem.current.SetSelectedGameObject(firstButtonOptions.gameObject);

        }
        else
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(firstButtonmainMenu.gameObject);

        }

    }

   

 

}
