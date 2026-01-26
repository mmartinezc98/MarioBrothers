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
        // Girar sprite según la dirección del movimiento
        if (_goomba.MovementDirection > 0)
            _sprite.flipX = true;
        else if (_goomba.MovementDirection < 0)
            _sprite.flipX = false;
    }

    public void PlayStomped()
    {
        if (_anim != null)
            _anim.SetTrigger("onStomped");
    }
}
