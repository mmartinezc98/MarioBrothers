using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] public GameObject firstSelectedButton;

    private bool isPaused = false;

    private void Awake()
    {
        // Activamos el mapa Player al inicio
        InputManager2.SwitchMap(InputManager2.InputSystemActions.Player);

        // Nos suscribimos a la acción de pausa del mapa Player
        InputManager2.InputSystemActions.Player.Pause.performed += OnPause;
        InputManager2.InputSystemActions.UI.Atras.performed += OnResume;
    }

    private void OnDestroy()
    {
        // Importante: desuscribir para evitar errores
        InputManager2.InputSystemActions.Player.Pause.performed -= OnPause;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        


        else Pause();
    }
    public void OnResume(InputAction.CallbackContext context) {
        if (isPaused) Resume();
    }

    void Pause()
    {
        // Cambiamos al mapa UI para navegar por botones
        InputManager2.SwitchMap(InputManager2.InputSystemActions.UI);

        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
       

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);

        // Volvemos al mapa Player
        InputManager2.SwitchMap(InputManager2.InputSystemActions.Player);
    }
}


