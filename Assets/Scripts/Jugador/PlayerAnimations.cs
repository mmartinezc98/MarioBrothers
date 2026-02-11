using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerController))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private PlayerController _player;

    private void Awake()
    {
        Main.CustomEvents.OnStatusChange.AddListener(SelectStatus);
    }
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _player = GetComponent<PlayerController>();

        
    }

    
    private void Update()
    {
        float speedX = Mathf.Abs(_rb.velocity.x);
        float inputX = _player.MovementDirection.x;

        // Flip del sprite según la dirección del movimiento
        if (inputX > 0)
            _sprite.flipX = false;   // mirando a la derecha
        else if (inputX < 0)
            _sprite.flipX = true;    // mirando a la izquierda



        // ---------------------------------------------------------
        //  PARÁMETROS DEL ANIMATOR
        // ---------------------------------------------------------

        // BlendTree Grounded (Idle/Walk)
        _anim.SetFloat("velocityX", speedX);

        // Salto / Suelo
        _anim.SetBool("isGrounded", _player.IsGrounded);

        
    }

    // ---------------------------------------------------------
    //  CAMBIO DE FORMA (SMALL / BIG / FIRE)
    // ---------------------------------------------------------
    public void SelectStatus(MarioStatus status)
    {
        // 0 = Small, 1 = Big, 2 = Fire
        _anim.SetInteger("MarioStatus", (int) status);

        _anim.SetTrigger("MarioStatusChange");
    }
}

