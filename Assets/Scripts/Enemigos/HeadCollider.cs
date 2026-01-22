using UnityEngine;
public class HeadCollider : MonoBehaviour
{
    private Enemies _enemy;
    [SerializeField] private float _reboundForce= 10f;

    private void Awake()
    {
        //para poder llamar al metodo OnStomped
        _enemy = GetComponentInParent<Enemies>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //para ver si colisiona con el Player
        {
            //llamamos a la clase de Enemies
            _enemy.OnStomped();

            // hacemos que cuando mario salte sobre el enemigo haga un rebote manteniendo la velocidad en x
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, _reboundForce);
        }
    }    
}

