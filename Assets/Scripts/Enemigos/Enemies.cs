using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemies : MonoBehaviour
{
    private Rigidbody2D _rb;

    //MOVIMIENTO
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private int _movementDirection = -1;

    //RAYCAST
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallRayLength = 0.6f;
    [SerializeField] private LayerMask _wallLayer;

    private void Awake()
    {
        this._rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Dibuja el raycast 
        Vector2 dir = Vector2.right * _movementDirection;
        Debug.DrawRay(_wallCheck.position, dir * _wallRayLength, Color.red);
    }

    private void FixedUpdate()
    {
        Move();
        WallCheck();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_movementDirection * _movementSpeed, _rb.velocity.y);
    }

    #region Raycast
    private void WallCheck()
    {
        Vector2 dir = Vector2.right * _movementDirection;

        bool wallHit = Physics2D.Raycast(
            _wallCheck.position,
            dir,
            _wallRayLength,
            _wallLayer
        );

        if (wallHit)
            TurnAway();
    }
    #endregion

    private void TurnAway()
    {
        _movementDirection *= -1;
    }
}
