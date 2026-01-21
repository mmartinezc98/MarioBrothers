using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    // private Animator _animator;
    // private SpriteRenderer _spriteRendered;

    #region VARIABLES

    //  Movimiento
    private Vector2 _movementDirection;                 // Dirección del input  
    [SerializeField] private float _moveSpeed = 4f;     // Velocidad base caminando
    [SerializeField] private float _acceleration = 20f; // Aceleración en suelo
    [SerializeField] private float _deceleration = 30f; // Frenado en suelo
    [SerializeField] private float _maxSpeed = 5f;      // Velocidad máxima horizontal

    //  Carrera 
    [SerializeField] private float _runSpeed = 6f;      // Velocidad máxima corriendo
    private bool running = false;                       // Si el jugador mantiene el botón de correr

    //  Salto 
    [SerializeField] private float _jumpForce = 10f;          // Fuerza inicial del salto
    [SerializeField] private float _shortJumpMultiplier = 3f; // Reduce salto si sueltas el botón
    [SerializeField] private float _fallMultiplier = 2f;       //Velocidad de caída
    private bool jumpHeld = false;                            // para ver si el botón de salto está mantenido

    //  Ground Check 
    [SerializeField] private Transform _groundCheck;      // Punto desde donde lanzamos el raycast
    [SerializeField] private float _groundRayLength = 0.2f;
    [SerializeField] private LayerMask _groundLayer;      // Capas que cuentan como suelo
    private bool isGrounded = false;                     // para ver si el jugador está tocando el suelo

    #endregion

    private void Awake()
    {
        this._rb = GetComponent<Rigidbody2D>();
        //_animator = GetComponent<Animator>();

        //RUN
        InputManager2.InputSystemActions.Player.Run.started += Run;

        //JUMP
        InputManager2.InputSystemActions.Player.Jump.started += JumpPressed;
        InputManager2.InputSystemActions.Player.Jump.canceled += JumpReleased;
    }
    private void Update()
    {
        CheckGround();       // Detecta si está en el suelo
        ApplyJumpPhysics();  // Aplica física del salto 
    }

    #region MOVIMIENTO
    

    private void FixedUpdate() //como el jugador se mueve con fuerzas(gravedad etc) se usa el fuxed Update (no depende de los frames)
    {
        _movementDirection = InputManager2.InputSystemActions.Player.Movement.ReadValue<Vector2>();
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
    private void JumpPressed(InputAction.CallbackContext callbackContext)
    {
        // Para saltar solo si estas tocando el suelo
        if (isGrounded && callbackContext.phase == InputActionPhase.Started)
        {
            jumpHeld = true;
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
        /*else
        {
            if (callbackContext.phase == InputActionPhase.Canceled)
            {
                jumpHeld = false;
            }
        }*/
    }

    private void JumpReleased(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Canceled)
        {
            jumpHeld = false;
        }
        
    }

    // Salto variable
    private void ApplyJumpPhysics()
    {
        // Caída más rápida
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _groundRayLength, _groundLayer);


        Debug.DrawRay(transform.position, Vector2.down * _groundRayLength, Color.red);

        isGrounded = hit.collider != null;
    }
    #endregion

    #region RUN
    private void Run(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            running = true;
        }else if(callbackContext.phase == InputActionPhase.Canceled)
        {
            running=false;
        }
        
    }
    #endregion
}