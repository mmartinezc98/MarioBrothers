using UnityEngine;

public class Goomba : Enemies
{
    private GoombaAnimations _goombaAnim;

    [Header("Aguante del sprite de muerte")]
    [SerializeField] private float _deadStanding;
    private CircleCollider2D _circleCollider;
    private BoxCollider2D _headCollider;

    private void Start()
    {
        _headCollider= GetComponentInChildren<BoxCollider2D>();
        _goombaAnim = GetComponent<GoombaAnimations>();
        _circleCollider = GetComponent<CircleCollider2D>();   
    }

    public override void OnStomped()
    {
        PlayerController player = FindAnyObjectByType<PlayerController>();

        // Incrementamos el combo y obtenemos los puntos antes de que se reseteen
        player.AddStompCombo();
        int points = player.GetLastComboPoints();

        // Mostramos el popup de puntos encima del goomba
        PointspopupSpawner.Spawn(points, transform.position);

        // Desactivamos los colliders para que no vuelva a colisionar con Mario
        _circleCollider.enabled = false;
        _headCollider.enabled = false;

        // Avisamos al script de animaciones para reproducir la animación de muerte
        if (_goombaAnim != null) _goombaAnim.PlayStomped();

        // Paramos el movimiento y desactivamos la física
        _movementDirection = 0;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

        Main.AudManager.PlaySound(Main.SoundLibrary.stomp);
        GetComponent<Collider2D>().enabled = false;

        // Destruimos el objeto tras el tiempo de espera configurado
        Destroy(gameObject, _deadStanding);
    }

    
    public override void OnSideHit()
    {
        Main.CustomEvents.OnDamageTaken.Invoke(); //invoca el evento cuando colisiona lateralmente con mario
    }

    
}
