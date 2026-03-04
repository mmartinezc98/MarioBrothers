using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUpBlock : BlockBase
{
    [Header("Power-Up Settings")]
    [SerializeField] private GameObject oneUpPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Sprite usedSprite;

    private SpriteRenderer sr;
    private bool hasBeenUsed = false;

    protected override void Awake()
    {
        base.Awake();
        sr = GetComponent<SpriteRenderer>();
    }

    protected override void OnHit(GameObject hitter)
    {
        if (hasBeenUsed)
            return;

        hasBeenUsed = true;

        SpawnPowerUp();

        state = BlockState.Used;
        OnBecomeUsed();
    }

    public override void SpawnPowerUp()
    {
        Vector3 pos = spawnPoint != null
            ? spawnPoint.position
            : transform.position + Vector3.up;

        Instantiate(oneUpPrefab, pos, Quaternion.identity);

        Main.AudManager.PlaySound(Main.SoundLibrary.powerUp);
    }

    protected override void OnBecomeUsed()
    {
        if (sr != null && usedSprite != null)
            sr.sprite = usedSprite;
    }


}
