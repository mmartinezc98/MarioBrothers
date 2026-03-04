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
        Main.Player.SetDifficulty(1);

    }
    private void Start()
    {
        Main.AudManager.StopMusic();
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);

    }
}
