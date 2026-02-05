using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemies : MonoBehaviour
{
    #region VARIABLES

    // Accesible desde clases hijas (Koopa, Goomba)
    protected Rigidbody2D _rb;

    // Movimiento
    [SerializeField] protected float _movementSpeed = 1f;
    [SerializeField] protected int _movementDirection = -1;

    // Raycast
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallRayLength = 0.6f;
    [SerializeField] private LayerMask _wallLayer;

    // Propiedad pública de solo lectura para animaciones
    public int MovementDirection => _movementDirection;

    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 dir = Vector2.right * _movementDirection;
        Debug.DrawRay(_wallCheck.position, dir * _wallRayLength, Color.red);
    }

    private void FixedUpdate()
    {
        Move();
        WallCheck();
    }

    // Ahora es virtual para que Koopa pueda sobrescribirlo
    protected virtual void Move()
    {
        _rb.velocity = new Vector2(_movementDirection * _movementSpeed, _rb.velocity.y);
    }

    #region MOVIMIENTO

    private void WallCheck()
    {
        Vector2 dir = Vector2.right * _movementDirection;

        bool wallHit = Physics2D.Raycast(_wallCheck.position, dir, _wallRayLength, _wallLayer);

        if (wallHit)
            TurnAway();
    }

    protected void TurnAway()
    {
        _movementDirection *= -1;
    }

    #endregion

    public virtual void OnStomped() { }

    public virtual void OnSideHit() { }

    public void OnCollisionEnter2D(Collision2D collision) //detecta las colisiones laterales de lso enemigos con mario (Player)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnSideHit();
        }
    }
}