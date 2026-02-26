using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    public float riseSpeed = 2f;

    private Rigidbody2D rb;
    private Collider2D col;
    private PowerUpsMain powerUp;

    private float riseDistance;
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool rising = true;

    public void Init(float blockHeight)
    {
        riseDistance = blockHeight;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        powerUp = GetComponent<PowerUpsMain>();

        // Guardamos posición inicial
        startPos = transform.position;
        targetPos = startPos + Vector3.up * riseDistance;

        // Desactivamos física
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;

        // Desactivamos movimiento del power-up
        powerUp.CanMove = false;
    }

    void Update()
    {
        if (rising)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, riseSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                rising = false;
                FinishRise();
            }
        }
    }

    void FinishRise()
    {
        rb.isKinematic = false;
        powerUp.CanMove = true;
        Destroy(this);
    }




}
