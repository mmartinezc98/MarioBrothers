using UnityEngine;

public class HeadHit : MonoBehaviour
{
    private BoxCollider2D _headCollider;

    private void Start()
    {
        _headCollider = GetComponent<BoxCollider2D>();
        Main.CustomEvents.OnStatusChange.AddListener(ChangeHeadCollider);

        // Ajusta el collider al estado actual al instanciarse
        ChangeHeadCollider(Main.Player.Status);
    }

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

    public void ChangeHeadCollider(MarioStatus status)
    {
       
        switch (status) {

             case MarioStatus.small:
                transform.localPosition = new Vector3(transform.localPosition.x, 1.02f, transform.localPosition.z);
                break;

             case MarioStatus.big:
                transform.localPosition =  new Vector3(transform.localPosition.x, 1.5f, transform.localPosition.z);
                break;

             case MarioStatus.fire:
                transform.localPosition = new Vector3(transform.localPosition.x, 1.5f, transform.localPosition.z);
                break;
        
        }
        
    }
}
