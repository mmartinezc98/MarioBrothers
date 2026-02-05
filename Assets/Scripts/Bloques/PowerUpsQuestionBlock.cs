using UnityEngine;

public class PowerUpsQuestionBlock : BlockBase
{
    [Header("Power-Up Settings")]
     
    [SerializeField] private GameObject _mushromPrefab;   // Prefab del powerup de la seta
    [SerializeField] private GameObject _firePlantPrefab;   // Prefab del powerup de la planta de fuego

    [SerializeField] private Transform _spawnPoint;       // punto donde se instancia el prefab
    [SerializeField] private Sprite _usedSprite;          // Sprite cuando el bloque queda gastado

    private SpriteRenderer _sr;
    private bool _hasBeenUsed = false;

    protected override void Awake()
    {
        base.Awake();
        _sr = GetComponent<SpriteRenderer>();
    }

    protected override void OnHit(GameObject hitter)
    {
        if (_hasBeenUsed)
            return;

        _hasBeenUsed = true;

        SpawnPowerUp();

        state = BlockState.Used;
        OnBecomeUsed();
    }

    public override void SpawnPowerUp()
    {
       

        //posicion del power up al instanciarlo
        Vector3 pos = _spawnPoint != null
            ? _spawnPoint.position
            : transform.position + Vector3.up;


        switch (Main.Player.Status){

            case MarioStatus.small:
                Instantiate(_mushromPrefab, pos, Quaternion.identity);
                break;
            case MarioStatus.big:
                Instantiate(_firePlantPrefab, pos, Quaternion.identity);
                break;
            case MarioStatus.fire:
                Instantiate(_firePlantPrefab, pos, Quaternion.identity);
                break;

        }       
    }

    protected override void OnBecomeUsed()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
            animator.SetBool("Used", true);
    }

   

}