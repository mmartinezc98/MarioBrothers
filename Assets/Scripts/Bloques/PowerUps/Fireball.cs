using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float bounceForce = 4f;
    [SerializeField] private float lifeTime = 3f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(int direction)
    {
        rb.velocity = new Vector2(direction * speed, 0);
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar colisiones contra la pared 
        if (Mathf.Abs(collision.contacts[0].normal.x)>.5f)
        {
            Destroy(gameObject);
         
        }
        else if (collision.contacts[0].normal.y <.5f) //detectar colisiones con el suelo
        {
            rb.velocity = new Vector2(rb.velocity.x, bounceForce);
        } 

        // Enemigos
        if (collision.collider.CompareTag("Enemy"))
        {
            ScoreManager.AddPoints(100); //añadimos los puntos a mario
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
    }
}
