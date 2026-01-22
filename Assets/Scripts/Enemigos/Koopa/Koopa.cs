using UnityEngine;

public class Koopa : Enemies
{
    public enum KoopaState
    {
        Walking,
        ShellIdle,
        ShellMoving,
        Returning
    }

    //VARIABLES
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float shellSpeed = 6f;
    [SerializeField] private float returnTime = 4f;

    private KoopaState _state = KoopaState.Walking;
    private float _returnTimer;

    private Rigidbody2D _rb;
    private Collider2D _bodyCollider;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _bodyCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        switch (_state)
        {
            case KoopaState.Walking:
                Walk();
                break;

            case KoopaState.ShellIdle:
                HandleShellIdle();
                break;

            case KoopaState.ShellMoving:
                // Movimiento ya lo controla la velocidad
                break;

            case KoopaState.Returning:
                // Aquí puedes poner animación de temblor
                break;
        }
    }

    public override void OnSideHit()
    {
        // Aquí decides qué pasa cuando un caparazón golpea al Koopa
        Destroy(gameObject);
    }
    private void Walk()
    {
        _rb.velocity = new Vector2(_movementDirection * walkSpeed, _rb.velocity.y);
    }

    private void HandleShellIdle()
    {
        _returnTimer -= Time.deltaTime;

        if (_returnTimer <= 0)
        {
            StartReturning();
        }
    }

    public override void OnStomped()
    {
        if (_state == KoopaState.Walking)
        {
            EnterShell();
        }
        else if (_state == KoopaState.ShellIdle)
        {
            LaunchShell();
        }
    }

    private void EnterShell()
    {
        _state = KoopaState.ShellIdle;
        _rb.velocity = Vector2.zero;

        // TODO: Cambiar sprite a caparazón
        _returnTimer = returnTime;
    }

    private void LaunchShell()
    {
        _state = KoopaState.ShellMoving;

        float direction = Mathf.Sign(_movementDirection);
        _rb.velocity = new Vector2(direction * shellSpeed, _rb.velocity.y);

        // TODO: animación de caparazón rodando
    }

    private void StartReturning()
    {
        _state = KoopaState.Returning;

        // TODO: animación de temblor
        Invoke(nameof(ExitShell), 1.5f);
    }

    private void ExitShell()
    {
        _state = KoopaState.Walking;
        // TODO: volver al sprite normal
    }

    public void HitSide()
    {
        if (_state == KoopaState.ShellMoving)
        {
            _movementDirection *= -1;
            _rb.velocity = new Vector2(_movementDirection * shellSpeed, _rb.velocity.y);
        }
    }
}