using UnityEngine;

public class KoopaShellCollider : MonoBehaviour
{
    private Koopa _koopa;

    private void Awake()
    {
        _koopa = GetComponentInParent<Koopa>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_koopa == null)
            return;

        if (collision.CompareTag("Enemy"))
        {
            Enemies enemy = collision.GetComponent<Enemies>();
            if (enemy != null)
                enemy.OnSideHit();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _koopa.HitSide();
        }

        if (collision.CompareTag("Player"))
        {
            // TODO: daño al jugador
        }
    }
}