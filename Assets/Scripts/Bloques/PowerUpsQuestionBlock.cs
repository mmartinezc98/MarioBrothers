using UnityEngine;

public class PowerUpsQuestionBlock : BlockBase
{
    [Header("Power-Up Settings")]
    [SerializeField] private GameObject _powerUpPrefab;   // Prefab del powerup
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

    private void SpawnPowerUp()
    {
        if (_powerUpPrefab == null)
            return;

        Vector3 pos = _spawnPoint != null
            ? _spawnPoint.position
            : transform.position + Vector3.up;

        Instantiate(_powerUpPrefab, pos, Quaternion.identity);
    }

    protected override void OnBecomeUsed()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
            animator.SetBool("Used", true);
    }
}