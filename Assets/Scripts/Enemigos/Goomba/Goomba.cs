using UnityEngine;

public class Goomba : Enemies
{
    private GoombaAnimations _goombaAnim;

    [Header("Aguante del sprite de muerte")]
    [SerializeField] private float _deadStanding;

    private void Start()
    {
        _goombaAnim = GetComponent<GoombaAnimations>();
    }

    public override void OnStomped()
    {
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
}
