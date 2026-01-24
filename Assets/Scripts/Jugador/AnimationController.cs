using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerController))]
public class PlayerAnimations : MonoBehaviour
{

    #region VARIABLES
    private Animator _anim;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private PlayerController _player;

    [Header("Configuración de Derrape")]
    [SerializeField] private float _minDriftVelocity = .5f;
    #endregion


    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        float speedX = Mathf.Abs(_rb.velocity.x);
        float inputX = _player.MovementDirection.x;

        // 1. Enviamos parámetros básicos al Animator
        _anim.SetFloat("velocityX", speedX);
        _anim.SetFloat("velocityY", _rb.velocity.y);
        _anim.SetBool("isGrounded", _player.IsGrounded);

        // 2. Lógica de Derrape (Drifting / Skidding)
        // Guardamos el resultado en una variable local llamada isDrifting
        bool isDrifting = _player.IsGrounded &&
                          speedX > _minDriftVelocity &&
                          ((inputX > 0 && _rb.velocity.x < -0.1f) ||
                           (inputX < 0 && _rb.velocity.x > 0.1f));

        // Pasamos esa variable al parámetro del Animator
        _anim.SetBool("isDrifting", isDrifting);

        // 3. Girar el Sprite (Flip)
        // Si está derrapando, NO giramos el sprite para que mantenga la pose de freno
        if (!isDrifting)
        {
            if (inputX > 0.1f) _sprite.flipX = false;
            else if (inputX < -0.1f) _sprite.flipX = true;
        }
    }
}

