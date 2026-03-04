using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour

{
    PlayerController playerController;
    private BoxCollider2D _bodyCollider; //collider del cuerpo
    private BoxCollider2D _headCollider; //headcollider

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();    //cogemos el playerController
        _bodyCollider = GetComponent<BoxCollider2D>();          //cogemos el box Colluder del cuerpo
        _headCollider = GetComponentInChildren<BoxCollider2D>(); //cogemos el boxcollider de la cabeza

        Main.CustomEvents.OnDamageTaken.AddListener(Takedamage);
        Main.CustomEvents.OnPowerUpTaken.AddListener(TakePowerUp);
        Main.CustomEvents.OnStatusChange.AddListener(AdjustColliders);
        // Ajusta los colliders al estado actual al instanciarse
        AdjustColliders(Main.Player.Status);

    }



    public void TakePowerUp() //cambia los estados dependiendo de los powerups que se recojan
    {
        switch (Main.Player.Status)
        {
            case MarioStatus.small:
                SetBig();
                Main.Player.PointsChange(1000);
                // Mostramos popup de puntos al recoger el champiñón rojo
                PointspopupSpawner.Spawn(1000, transform.position);
                break;

            case MarioStatus.big:
                SetFire();
                Main.Player.PointsChange(1000);
                // Mostramos popup de puntos al recoger la planta de fuego
                PointspopupSpawner.Spawn(1000, transform.position);
                break;

            case MarioStatus.fire:
                // Ya tiene el estado máximo, no se muestran puntos
                break;
        }
    }

    public void Takedamage() //cambia los estados cuando mario recibe daño
    {

        switch (Main.Player.Status)
        {
            case MarioStatus.small:
                Death();
                break;

            case MarioStatus.big:
                Main.AudManager.PlaySound(Main.SoundLibrary.pipeDown);
                SetSmall();
                break;

            case MarioStatus.fire:
                Main.AudManager.PlaySound(Main.SoundLibrary.pipeDown);
                SetBig();
                break;
        }

    }


    public void Death()
    {
        //restamos una ida a mario
        Main.Player.RestLifes(1);

        Destroy(this.gameObject);

        Debug.Log("Moruto");
    }

    public void SetSmall() //cambia el estado a pequeño
    {
        SetSmallColliders();

        Main.Player.ChangeStatus(MarioStatus.small);
        Main.CustomEvents.OnPlayerDead.Invoke();
        //Debug.Log("Mario es pequeño");
    }

    public void SetBig() //cambia el estado a grande
    {
        Main.AudManager.PlaySound(Main.SoundLibrary.pipeDown);
        SetBigColliders();
        Main.Player.ChangeStatus(MarioStatus.big);
        Main.AudManager.PlaySound(Main.SoundLibrary.grow);


        //Debug.Log("Mario es grande");
    }

    public void SetFire() //cambia el estado a fuego
    {
        SetBigColliders();
        Main.Player.ChangeStatus(MarioStatus.fire);
        Main.AudManager.PlaySound(Main.SoundLibrary.grow);


        //Debug.Log("Mario es de fuego");
    }



    private void AdjustColliders(MarioStatus status)
    {
        switch (status)
        {
            case MarioStatus.small:
                SetSmallColliders();
                break;

            case MarioStatus.big:
                SetBigColliders();
                break;

            case MarioStatus.fire:

                break;
        }
    }


    private void SetSmallColliders()
    {
       
        // Cambiar collider del cuerpo
        Vector2 size = _bodyCollider.size;
        size.y = 1.046902f;                     // tamaño pequeño
        _bodyCollider.size = size;
    }

    private void SetBigColliders()
    {

        // Cambiar collider del cuerpo
        Vector2 size = _bodyCollider.size;
        size.y = 2f;                     // tamaño grande
        _bodyCollider.size = size;

    }
}
