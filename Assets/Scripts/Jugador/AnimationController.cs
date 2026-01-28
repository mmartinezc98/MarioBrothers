using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerController))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _anim;              // Controla las animaciones
    private Rigidbody2D _rb;             // Para leer velocidad y dirección
    private SpriteRenderer _sprite;      // Para voltear el sprite
    private PlayerController _player;    // Para leer inputs y estados del jugador

    
    [Header("Configuración de Derrape")]
    [SerializeField] private float _minDriftVelocity = .5f;
    // Velocidad mínima para activar la animación de derrape

    // ---------------------------------------------------------
    //  INICIALIZACIÓN
    // ---------------------------------------------------------
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _player = GetComponent<PlayerController>();
    }

    // ---------------------------------------------------------
    //  ACTUALIZACIÓN DE ANIMACIONES
    // ---------------------------------------------------------
    private void Update()
    {
        float speedX = Mathf.Abs(_rb.velocity.x);   // Velocidad horizontal absoluta
        float inputX = _player.MovementDirection.x; // Input horizontal del jugador

        // -----------------------------------------------------
        //  PARÁMETROS DEL ANIMATOR
        // -----------------------------------------------------

        // Velocidad horizontal para Idle/Walk/Run
        _anim.SetFloat("velocityX", speedX);

        // Velocidad vertical para Jump/Fall
        _anim.SetFloat("velocityY", _rb.velocity.y);

        // Saber si está tocando el suelo
        _anim.SetBool("isGrounded", _player.IsGrounded);

        // -----------------------------------------------------
        //  LÓGICA DE DERRAPE (SKIDDING)
        // -----------------------------------------------------
        bool isDrifting =
            _player.IsGrounded &&                   // Solo en el suelo
            speedX > _minDriftVelocity &&           // Debe ir rápido
            (
                (inputX > 0 && _rb.velocity.x < -0.1f) ||   // Input derecha + velocidad izquierda
                (inputX < 0 && _rb.velocity.x > 0.1f)       // Input izquierda + velocidad derecha
            );

        _anim.SetBool("isDrifting", isDrifting);

        // -----------------------------------------------------
        //  FLIP DEL SPRITE (solo si no está derrapando)
        // -----------------------------------------------------
        if (!isDrifting)
        {
            if (inputX > 0.1f) _sprite.flipX = false;
            else if (inputX < -0.1f) _sprite.flipX = true;
        }
    }

    // ---------------------------------------------------------
    //  CAMBIO DE FORMA (SMALL / BIG / FIRE)
    // ---------------------------------------------------------
    /// <summary>
    /// Cambia el parámetro "marioForm" del Animator.
    /// Este parámetro decide qué conjunto de animaciones usar:
    /// 0 = Small, 1 = Big, 2 = Fire.
    /// Lo llama la máquina de estados de tamaño.
    /// </summary>
    public void SetForm(int form)
    {
        _anim.SetInteger("marioForm", form);
    }
}

