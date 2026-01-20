using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//Nos aseguramos que sea necesario un Player input en nuestro player para que funcione
[RequireComponent(typeof(PlayerInput))]

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }


    private PlayerInput _playerInput;
    public PlayerInput PlayerInput { get { return this._playerInput; } }


    //CREACION DE EVENTOS
    public UnityEvent<Vector2> OnMove;
    public UnityEvent OnJumpPressed; //evento al pulsar el boton (mas pulsado, mas salta)
    public UnityEvent OnJumpReleased; //evento al soltar el boton (para cancelar el salto)
    public UnityEvent<bool> OnRun;


    //SINGLETON
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Instance._playerInput = GetComponent<PlayerInput>();
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }


    //MOVIMIENTO
    public void InvokeOnMove(InputAction.CallbackContext callbackContext)
    {
        OnMove?.Invoke(callbackContext.ReadValue<Vector2>());
    }

    //SALTO
    public void InvokeOnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            OnJumpPressed?.Invoke();
        }


        if (callbackContext.canceled)
        {
            OnJumpReleased?.Invoke();
        }

    }

    //CORRER
    public void InvokeOnRun(InputAction.CallbackContext callbackContext) //para ver cuando esta corriedo o no (true/false)
    {
        if (callbackContext.started)
            OnRun?.Invoke(true);

        if (callbackContext.canceled)
            OnRun?.Invoke(false);
    }

}




