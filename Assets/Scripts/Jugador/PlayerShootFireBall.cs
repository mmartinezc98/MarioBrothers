using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootFireBall : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform firePoint;

    private float shootCooldown = 0.3f;
    private float lastShootTime = 0f;

    void Update()
    {
        if (Main.Player.Status != MarioStatus.fire)
            return;

        if (Input.GetKeyDown(KeyCode.X) && Time.time > lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }
    // Este método lo llama automáticamente el PlayerInput
    public void OnShoot(InputValue value)
    {
        Debug.Log("OnShoot llamado");

        if (!value.isPressed)
            return;

        if (Main.Player.Status != MarioStatus.fire)
            return;

        if (Time.time < lastShootTime + shootCooldown)
            return;

        Shoot();
        lastShootTime = Time.time;
    }


    private void Shoot()
    {
        int direction =(int) Mathf.Sign(transform.lossyScale.x) > 0 ? 1 : -1; //detecta la direccion real del padre

        GameObject fb = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        fb.GetComponent<Fireball>().Launch(direction);

        Main.AudManager.PlaySound(Main.SoundLibrary.fireball);
    }
}


