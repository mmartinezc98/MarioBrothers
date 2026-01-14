using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    #region VARIABLES
    //movimiento
    private Vector2 _movementDirection;
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _acceleration;
    //[SerializeField] private float _deceleration;
    //[SerializeField] private float _maxSpeed= 5f;

    //carrera
    [SerializeField] private float _runSpeed;
    private bool running = false;

    //salto
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _shortJumpMultiplier = 3f;
    [SerializeField] private float fallMultiplier = 2f; //controlar a la velocidad a la que cae del salto

    private bool jumpHeld = false; //controla si el boton esta mantenido  

    // Groundcheck con raycast
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRayLength = 0.2f;
    [SerializeField] private LayerMask groundLayer; //necesario para el raycast (capa con la que interactua)

    private bool isGrounded = false; //controla si el jugador esta en el suelo
    #endregion

    private void Awake()
    {
        this._rb = GetComponent<Rigidbody2D>();

        //SUSCRIPCION A EVENTOS
        InputManager.Instance.OnMove.AddListener(Move);
        InputManager.Instance.OnJumpPressed.AddListener(JumpPressed);
        InputManager.Instance.OnJumpReleased.AddListener(JumpReleased);
        //InputManager.Instance.OnRun.AddListener(Run);


    }

    private void Update()
    {
        CheckGround();
        ApplyJumpPhysics();
    }

    #region MOVIMIENTO
    public void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_movementDirection.x * _moveSpeed, _rb.velocity.y);
    }
    #endregion

    #region SALTO

    //al pulsar el boton del salto
    private void JumpPressed()
    {
        if (isGrounded) //si el player esta en el suelo aplica la fuerza de salto
        {
            jumpHeld = true;
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    //al soltar el boton del salto
    private void JumpReleased()
    {
        jumpHeld = false;
    }

    // Física del salto variable
    private void ApplyJumpPhysics()
    {
        // para caer mas rapido
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // para acortar el salto si se suelta el boton
        else if (_rb.velocity.y > 0 && !jumpHeld)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (_shortJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    // GroundCheck con Raycast
    private void CheckGround()
    {
        Vector2 origin = groundCheck.position;
        Vector2 direction = Vector2.down;

        Debug.DrawRay(origin, direction * groundRayLength, Color.red); //pone el raycast en rojo (comprobacion)

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, groundRayLength, groundLayer); //hit es el GObj con el q ha colisionado el raycast.

        isGrounded = hit.collider != null;
    }
    #endregion

    public void Run()
    {

    }
}
