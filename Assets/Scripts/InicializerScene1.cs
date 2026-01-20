using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializerScene1 : MonoBehaviour //PARA INICIALIZAR TODO LO NECESARIO EN LA ESCENA
{
    private void Awake()
    {
        InputManager2.SwitchMap(InputManager2.InputSystemActions.Player); //inicializamos el input managerm de los controles de mario
    }
}
