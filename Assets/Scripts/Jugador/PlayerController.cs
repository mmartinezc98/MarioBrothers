using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    #region VARIABLES

    [Header("Movimiento")]
    [SerializeField] private float _moveSpeed = 6f;
    [SerializeField] private float _runSpeed = 9f;
    [SerializeField] private float _acceleration = 12f;
    [SerializeField] private float _deceleration = 12f;
    private Vector2 _movementDirection;
    private bool _isRunning = false;

    [Header("Salto")]
    [SerializeField] private float _jumpForce = 12f;
    [SerializeField] private float _fallMultiplier = 3f;
    [SerializeField] private float _shortJumpMultiplier = 4f;
    private bool _jumpHeld = false;

    [Header("Raycast")]
    [SerializeField] private float _groundRayLength = 0.2f;
    [SerializeField] private float _groundRayOffset = 0.3f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _isGrounded;

    #endregion

    #region ANIMACIONES

    // Estas propiedades permiten que otros scripts lean el estado pero no lo modifiquen
    public bool IsGrounded => _isGrounded;
    public bool IsRunning => _isRunning;
    public Vector2 MovementDirection => _movementDirection;
    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    //SUSCRIPCION A EVENTOS
    private void OnEnable()
    {
        InputManager2.InputSystemActions.Player.Run.started += OnRun;
        InputManager2.InputSystemActions.Player.Run.canceled += OnRun;
        InputManager2.InputSystemActions.Player.Jump.started += OnJumpPressed;
        InputManager2.InputSystemActions.Player.Jump.canceled += OnJumpReleased;
        InputManager2.InputSystemActions.Player.Enable();
    }


    //DESUSCRIPCION A EVENTOS
    private void OnDisable()
    {
        InputManager2.InputSystemActions.Player.Run.started -= OnRun;
        InputManager2.InputSystemActions.Player.Run.canceled -= OnRun;
        InputManager2.InputSystemActions.Player.Jump.started -= OnJumpPressed;
        InputManager2.InputSystemActions.Player.Jump.canceled -= OnJumpReleased;
        InputManager2.InputSystemActions.Player.Disable();
    }

    private void Update()
    {
        _isGrounded = CheckGround();
        ApplyJumpPhysics();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    #region MOVIMIENTO

    private void HandleMovement()
    {
        _movementDirection = InputManager2.InputSystemActions.Player.Movement.ReadValue<Vector2>();

        float targetSpeed = _movementDirection.x * (_isRunning ? _runSpeed : _moveSpeed);
        float speedDif = targetSpeed - _rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _acceleration : _deceleration;

        float movement = speedDif * accelRate;
        _rb.AddForce(movement * Vector2.right, ForceMode2D.Force);

        // COMENTADO: Si usas el script de animaciones con flipX, esta lógica ya no es necesaria aquí.
        // if (_movementDirection.x != 0) transform.localScale = new Vector3(Mathf.Sign(_movementDirection.x), 1, 1);
    }

    private void OnRun(InputAction.CallbackContext ctx) => _isRunning = ctx.ReadValueAsButton();

    #endregion

    #region SALTO

    private void OnJumpPressed(InputAction.CallbackContext ctx)
    {
        if (_isGrounded)
        {
            _jumpHeld = true;
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void OnJumpReleased(InputAction.CallbackContext ctx) => _jumpHeld = false;

    private void ApplyJumpPhysics()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rb.velocity.y > 0 && !_jumpHeld)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (_shortJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    #endregion

    #region RAYCAST

    private bool CheckGround()
    {
        Vector2 pos = transform.position;
        bool center = Physics2D.Raycast(pos, Vector2.down, _groundRayLength, _groundLayer);
        bool left = Physics2D.Raycast(pos + Vector2.left * _groundRayOffset, Vector2.down, _groundRayLength, _groundLayer);
        bool right = Physics2D.Raycast(pos + Vector2.right * _groundRayOffset, Vector2.down, _groundRayLength, _groundLayer);

        Debug.DrawRay(pos, Vector2.down * _groundRayLength, Color.red);

        return center || left || right;
    }

    #endregion
}