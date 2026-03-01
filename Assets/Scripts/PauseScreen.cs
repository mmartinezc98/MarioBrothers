using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PauseScreen : MonoBehaviour
{
   [SerializeField]public GameObject pauseMenuUI;
   [SerializeField]public GameObject firstSelectedButton;

    private bool isPaused = false;

    private void Awake()
    {
        
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (isPaused) Resume();
        else Pause();
    }

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);

        // Seleccionar automáticamente el primer botón
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

 
}
