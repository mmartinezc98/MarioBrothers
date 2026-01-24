using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class GoombaAnimations : MonoBehaviour
{
    private Animator _anim;
    private Goomba _goomba;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _goomba = GetComponent<Goomba>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // 1. Giro del sprite basado en la dirección de movimiento del script Enemies
        if (_goomba._movementDirection > 0) _sprite.flipX = true;
        else if (_goomba._movementDirection < 0) _sprite.flipX = false;
    }

    // Este método lo llamaremos desde el script de lógica cuando Mario lo pise
    public void PlayStomped()
    {
        if (_anim != null)
        {
            // Cambiamos "onStomped" por "Dead" para que coincida con tu Animator
            _anim.SetTrigger("onStomped");
        }
    }
}
