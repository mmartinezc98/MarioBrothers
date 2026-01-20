using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager2 //SINGLETON DEL PLAYER INPUT PARA ASEGURAR QUE SOOLO HAYA UNO
{
    private static InputSystem _inputSystem; //PlayerInpus es el nombre de la clase que genera unity

    public static InputSystem InputSystemActions
    {
        get
        {
            if (InputSystemActions == null)
            {
                _inputSystem = new InputSystem();
                _inputSystem.Player.Enable();
            }
            return _inputSystem;
        }
    }

    public static void SwitchMap(InputActionMap mapToActivate)
    {

        InputSystemActions.Disable(); //desactivamos todos los mapas de control activos actualmente 

        mapToActivate.Enable(); //activamos el que queremos 

    }
}
