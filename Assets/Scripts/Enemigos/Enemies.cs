using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemies : MonoBehaviour
{

    #region VARIABLES
    private Rigidbody2D _rb;

    //MOVIMIENTO
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] public int _movementDirection = -1;

    //RAYCAST
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallRayLength = 0.6f;
    [SerializeField] private LayerMask _wallLayer;

    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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

    //Movimineto básico de los enemigos
    private void Move()
    {
        _rb.velocity = new Vector2(_movementDirection * _movementSpeed, _rb.velocity.y);
    }

    #region MOVIMIENTO

    //RAYCAST
    private void WallCheck()
    {
        Vector2 dir = Vector2.right * _movementDirection;

        bool wallHit = Physics2D.Raycast(_wallCheck.position, dir, _wallRayLength, _wallLayer);

        if (wallHit)
            TurnAway();
    }    

    // MÉTODO PARA CAMBIAR LA DIRECCION AL CHOCHAR    
    private void TurnAway()
    {
        _movementDirection *= -1;
    }

    #endregion

    //Metodo para cuando mario salta sobre los enemigos
    public virtual void OnStomped()
    {
        
    }

    public virtual void OnSideHit()
    {
        

    }
}
