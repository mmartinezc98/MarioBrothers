using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] public GameObject firstSelectedButton;

    private bool isPaused = false;
    private Vector2 _savedVelocity; // Guardamos la velocidad antes de pausar
    private Rigidbody2D _playerRb;

    private void Awake()
    {
        InputManager2.SwitchMap(InputManager2.InputSystemActions.Player);
        InputManager2.InputSystemActions.Player.Pause.performed += OnPause;
        InputManager2.InputSystemActions.UI.Atras.performed += OnResume;
    }

    private void OnDestroy()
    {
        InputManager2.InputSystemActions.Player.Pause.performed -= OnPause;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Pause();
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (isPaused) Resume();
    }

    void Pause()
    {
        // Buscamos el Rigidbody2D de Mario y guardamos su velocidad
        PlayerController mario = FindAnyObjectByType<PlayerController>();
        if (mario != null)
        {
            _playerRb = mario.GetComponent<Rigidbody2D>();
            _savedVelocity = _playerRb.velocity;
            _playerRb.velocity = Vector2.zero;
            _playerRb.isKinematic = true; // Evita que la física actúe mientras está pausado
        }

        Main.AudManager.PlaySound(Main.SoundLibrary.pause);
        InputManager2.SwitchMap(InputManager2.InputSystemActions.UI);

        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }

    public void Resume()
    {
        // Restauramos la física de Mario
        if (_playerRb != null)
        {
            _playerRb.isKinematic = false;
            _playerRb.velocity = _savedVelocity;
        }

        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);

        InputManager2.SwitchMap(InputManager2.InputSystemActions.Player);
    }
}


