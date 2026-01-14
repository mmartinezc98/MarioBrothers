using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    #region VARIABLES

    // --- Movimiento ---
    private Vector2 _movementDirection;                 // Dirección del input  
    [SerializeField] private float _moveSpeed = 4f;     // Velocidad base caminando
    [SerializeField] private float _acceleration = 20f; // Aceleración en suelo
    [SerializeField] private float _deceleration = 30f; // Frenado en suelo
    [SerializeField] private float _maxSpeed = 5f;      // Velocidad máxima horizontal

    // --- Carrera ---
    [SerializeField] private float _runSpeed = 6f;      // Velocidad máxima corriendo
    private bool running = false;                       // Si el jugador mantiene el botón de correr

    // --- Salto ---
    [SerializeField] private float _jumpForce = 10f;          // Fuerza inicial del salto
    [SerializeField] private float _shortJumpMultiplier = 3f; // Reduce salto si sueltas el botón
    [SerializeField] private float fallMultiplier = 2f;       // Aumenta velocidad de caída
    private bool jumpHeld = false;                            // Si el botón de salto está mantenido

    // --- Ground Check ---
    [SerializeField] private Transform groundCheck;      // Punto desde donde lanzamos el raycast
    [SerializeField] private float groundRayLength = 0.2f;
    [SerializeField] private LayerMask groundLayer;      // Capas que cuentan como suelo
    private bool isGrounded = false;                     // Si el jugador está tocando el suelo

    #endregion
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        // Suscripción a eventos del InputManager
        InputManager.Instance.OnMove.AddListener(Move);
        InputManager.Instance.OnJumpPressed.AddListener(JumpPressed);
        InputManager.Instance.OnJumpReleased.AddListener(JumpReleased);
        InputManager.Instance.OnRun.AddListener(Run);
    }
    private void Update()
    {
        CheckGround();       // Detecta si está en el suelo
        ApplyJumpPhysics();  // Aplica física del salto variable
    }

    #region MOVIMIENTO

    // Recibe el input del InputManager
    public void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void FixedUpdate()
    {
        // Velocidad actual y objetivo
        float currentSpeed = _rb.velocity.x;
        float baseSpeed = running ? _runSpeed : _moveSpeed;   // Usar el _runSpeed si se corre
        float targetSpeed = _movementDirection.x * baseSpeed; // Velocidad  según input

        float speedDiff = targetSpeed - currentSpeed;    // Diferencia entre actual y objetivo
        float accelRate;

        //Para que acelere y desacelere dependiendo cuando esta en el suelo
        if (isGrounded)
        {
            // acelara o desacelera dependiendo de si detecta un input o no
            accelRate = Mathf.Abs(targetSpeed) > 0.01f ? _acceleration : _deceleration;
        }
        else
        {
            // para no frenarse en el aire
            if (Mathf.Abs(targetSpeed) > 0.01f)
                accelRate = _acceleration * 0.5f; //Baja la aceleracion en el aire para que vaya mas lento
            else
                accelRate = 0f; // Mantener velocidad horizontal
        }

        // Se aplica la fuerza al rigidbody
        float movement = speedDiff * accelRate;
        _rb.AddForce(new Vector2(movement, 0f));

        // Limitacion de la velocidad maxima
        float clampedX = Mathf.Clamp(_rb.velocity.x, -_maxSpeed, _maxSpeed);
        _rb.velocity = new Vector2(clampedX, _rb.velocity.y);
    }
    #endregion

    #region SALTO
    private void JumpPressed()
    {
        // Para saltar solo si estas tocando el suelo
        if (isGrounded)
        {
            jumpHeld = true;
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void JumpReleased()
    {
        jumpHeld = false;
    }

    // Salto variable
    private void ApplyJumpPhysics()
    {
        // Caída más rápida
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        // Salto más corto si sueltas el botón
        else if (_rb.velocity.y > 0 && !jumpHeld)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (_shortJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    #endregion

    #region GROUND CHECK
    private void CheckGround()
    {
        // Raycast hacia abajo para detectar suelo
        RaycastHit2D hit = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            groundRayLength,
            groundLayer
        );

        Debug.DrawRay(groundCheck.position, Vector2.down * groundRayLength, Color.red);

        isGrounded = hit.collider != null;
    }
    #endregion

    #region RUN
    private void Run(bool isRunning)
    {
        running = isRunning;
    }
    #endregion
}