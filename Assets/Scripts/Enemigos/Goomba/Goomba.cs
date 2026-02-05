using UnityEngine;

public class Goomba : Enemies
{
    private GoombaAnimations _goombaAnim;

    [Header("Aguante del sprite de muerte")]
    [SerializeField] private float _deadStanding;
    private CircleCollider2D _circleCollider;
    private BoxCollider2D _headCollider;

    private void Start()
    {
        _headCollider= GetComponentInChildren<BoxCollider2D>();
        _goombaAnim = GetComponent<GoombaAnimations>();
        _circleCollider = GetComponent<CircleCollider2D>();   
    }

    public override void OnStomped()
    {
        //desactivamos los colliders del goomba y de la cabeza para que no colisione con mario otra vez
       _circleCollider.enabled = false;
       _headCollider.enabled = false;   
       
        // 1. Avisar al script de animaciones
        if (_goombaAnim != null) _goombaAnim.PlayStomped();

        // 2. Lógica física: parar y desactivar
        _movementDirection = 0;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

        GetComponent<Collider2D>().enabled = false;

        // destruye el objeto despues del tiempo de espera
        Destroy(gameObject, _deadStanding);
    }

    
    public override void OnSideHit()
    {
        Main.CustomEvents.OnDamageTaken.Invoke(); //invoca el evento cuando colisiona lateralmente con mario
    }

    
}
