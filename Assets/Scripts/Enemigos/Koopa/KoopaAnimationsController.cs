using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class KoopaAnimationsController : MonoBehaviour
{
    private Animator _anim;
    private Koopa _koopa;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _koopa = GetComponent<Koopa>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleSpriteFlip();
        UpdateAnimation();
    }

    private void HandleSpriteFlip()
    {
        if (_koopa.MovementDirection > 0)
            _sprite.flipX = true;
        else if (_koopa.MovementDirection < 0)
            _sprite.flipX = false;
    }

    // Llamado desde Koopa y también cada frame
    public void UpdateAnimation()
    {
        bool shellMode =
            _koopa.CurrentState == Koopa.KoopaState.ShellIdle ||
            _koopa.CurrentState == Koopa.KoopaState.ShellMoving;
       // Debug.Log("Modo concha" + shellMode);
        _anim.SetBool("isShell", shellMode);
    }
}