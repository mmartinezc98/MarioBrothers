using UnityEngine;

public class KoopaHeadCollider : MonoBehaviour
{
    private Koopa _koopa;

    private void Awake()
    {
        _koopa = GetComponentInParent<Koopa>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _koopa.OnStomped();

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
    }
}
