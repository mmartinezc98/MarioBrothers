using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpsMain : MonoBehaviour
{
    #region VARIABLES
    private Rigidbody2D _rb;

    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 2f;
    private int direction = 1; // empieza hacia la derecha

    [Header("Raycasts")]
    [SerializeField] private float wallRayLength = 0.25f;
    [SerializeField] private float groundRayLength = 0.25f;
    [SerializeField] private LayerMask groundLayer;

    private bool hasTouchedGround = false;

    private float halfWidth;   // ancho del sprite para raycasts laterales
    private float halfHeight;  // alto del sprite para raycast vertical
    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        // obtenemos el tamaño del collider para lanzar el raycast
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        halfWidth = col.size.x * 0.5f;
        halfHeight = col.size.y * 0.5f;
    }

    private void FixedUpdate()
    {
        Move();
        CheckGroundStatus();
        CheckForTurn();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(direction * moveSpeed, _rb.velocity.y);
    }

    private void CheckGroundStatus()
    {
        // Raycast vertical desde la base del sprite
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - halfHeight);

        bool groundHit = Physics2D.Raycast(origin, Vector2.down, groundRayLength, groundLayer);

        Debug.DrawRay(origin, Vector2.down * groundRayLength, Color.yellow);

        if (groundHit)
            hasTouchedGround = true;
    }

    private void CheckForTurn()
    {
        if (!hasTouchedGround)
            return;

        // Raycast lateral desde el borde del sprite
        Vector2 sideOrigin = new Vector2(transform.position.x + direction * halfWidth, transform.position.y);

        bool wallHit = Physics2D.Raycast(sideOrigin, Vector2.right * direction, wallRayLength, groundLayer);

        // Raycast hacia abajo desde el borde del sprite
        Vector2 edgeOrigin = new Vector2(transform.position.x + direction * halfWidth, transform.position.y - halfHeight);
        bool noGround = !Physics2D.Raycast(edgeOrigin, Vector2.down, groundRayLength, groundLayer);

        Debug.DrawRay(sideOrigin, Vector2.right * direction * wallRayLength, Color.red);
        Debug.DrawRay(edgeOrigin, Vector2.down * groundRayLength, Color.green);

        if (wallHit || noGround)
            direction *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collisiono con Mario");
            ApplyPowerUp();
            Destroy(gameObject);
            
        }
    }

    public virtual void ApplyPowerUp()
    {

    }

}
