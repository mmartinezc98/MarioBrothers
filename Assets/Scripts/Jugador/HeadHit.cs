using UnityEngine;

public class HeadHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BlockBase block = collision.collider.GetComponent<BlockBase>(); //crea la referencia del bloque base con el que se colisiona para que se ejecuten los metodos

        if (block != null) 
        {
            foreach (var contact in collision.contacts) //restriccion del angulo de colision de los colliders (para que solo sea desde abajo)
            {
                if (contact.normal.y < -0.5f)
                {
                    block.HitFromBelow(gameObject); //llamamos al metodo HitFromBelow
                    break;
                }
            }
        }
    }
}
