using UnityEngine;

public class Koopa : Enemies
{
    public enum KoopaState
    {
        Walking,
        ShellIdle,
        ShellMoving
    }

    public KoopaState CurrentState => _state;

    [SerializeField] private float _shellMoveSpeed = 6f;

    private KoopaState _state = KoopaState.Walking;

    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    protected override void Move()
    {
        switch (_state)
        {
            case KoopaState.Walking:
                _rb.velocity = new Vector2(_movementDirection * _movementSpeed, _rb.velocity.y);
                break;

            case KoopaState.ShellIdle:
                _rb.velocity = new Vector2(0f, _rb.velocity.y);
                break;

            case KoopaState.ShellMoving:
                _rb.velocity = new Vector2(_movementDirection * _shellMoveSpeed, _rb.velocity.y);
                break;
        }
    }

    public override void OnStomped()
    {
        switch (_state)
        {
            case KoopaState.Walking:
                EnterShell();
                break;

            case KoopaState.ShellIdle:
                //StartShellMoving();
                break;

            case KoopaState.ShellMoving:
                StopShell();
                break;
        }
    }

    private void EnterShell()
    {
        _state = KoopaState.ShellIdle;
        _rb.velocity = Vector2.zero;

        GetComponent<KoopaAnimationsController>()?.UpdateAnimation();

        _collider.size = new Vector2(1, 1);
        _collider.offset = Vector2.zero;
    }

    private void StartShellMoving(Vector2 marioPosition)
    {
        _state = KoopaState.ShellMoving;

        if (marioPosition.x > transform.position.x)
            _movementDirection = -1;
        else
            _movementDirection = 1;

        GetComponent<KoopaAnimationsController>()?.UpdateAnimation();
    }

    private void StopShell()
    {
        _state = KoopaState.ShellIdle;
        _rb.velocity = Vector2.zero;

        GetComponent<KoopaAnimationsController>()?.UpdateAnimation();
    }

    // NUEVO: golpe lateral a la concha
    public override void OnSideHit()
    {
        if (_state == KoopaState.ShellIdle)
        {
            _movementDirection *= -1;
            _state = KoopaState.ShellMoving;

            GetComponent<KoopaAnimationsController>()?.UpdateAnimation();
        }
    }
}