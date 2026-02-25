using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPrincipalInicializer : MonoBehaviour
{
    [SerializeField]public GameObject firstSelectedButton;

    private void Awake()
    {
        InputManager2.SwitchMap(InputManager2.InputSystemActions.UI); //inicializamos el input manager de los controles de la UI

    }
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);

    }
}
