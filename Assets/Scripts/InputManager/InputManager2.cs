using UnityEngine.InputSystem;

public class InputManager2 //SINGLETON DEL PLAYER INPUT PARA ASEGURAR QUE SOOLO HAYA UNO
{
    private static PlayerInputActions _inputSystem; //InputSystem es el nombre de la clase que genera unity

    public static PlayerInputActions InputSystemActions
    {
        get
        {
            if (_inputSystem == null)
            {
                _inputSystem = new PlayerInputActions();
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
