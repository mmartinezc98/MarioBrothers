using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour

{
    PlayerController playerController;
    private BoxCollider2D _bodyCollider; //collider del cuerpo
    private BoxCollider2D _headCollider; //headcollider

    private void Start()
    {
        playerController = GetComponent<PlayerController>();    //cogemos el playerController
        _bodyCollider = GetComponent<BoxCollider2D>();          //cogemos el box Colluder del cuerpo
        _headCollider = GetComponentInChildren<BoxCollider2D>(); //cogemos el boxcollider de la cabeza

        Main.CustomEvents.OnDamageTaken.AddListener(Takedamage);
        Main.CustomEvents.OnPowerUpTaken.AddListener(TakePowerUp);
       

    } 

    

    public void TakePowerUp() //cambia los estados dependiendo de los powerups que se recojan
    {
        switch (Main.Player.Status)
        {
            case MarioStatus.small:
                SetBig();
                break;

            case MarioStatus.big:
                SetFire();
                break;

            case MarioStatus.fire:
                Debug.Log("wow");
                break;
        }
    }

    public void Takedamage() //cambia los estados cuando mario recibe daño
    {
        switch (Main.Player.Status) { 
            case MarioStatus.small:
                Death();
            break;

        case MarioStatus.big:
            SetSmall();
            break;

        case MarioStatus.fire:
             SetBig();
            break;
        }

    }

    public void Death()
    {
        Debug.Log("Moruto");
    }

    public void SetSmall() //cambia el estado a pequeño
    {
        SetSmallColliders();
        Main.Player.ChangeStatus(MarioStatus.small);
       
         

        Debug.Log("Mario es pequeño");
    }

    public void SetBig() //cambia el estado a grande
    {
        SetBigColliders();
        Main.Player.ChangeStatus(MarioStatus.big);
        
        
        Debug.Log("Mario es grande");
    }

    public void SetFire() //cambia el estado a fuego
    {
        SetBigColliders();
        Main.Player.ChangeStatus(MarioStatus.fire);
        
        
        Debug.Log("Mario es de fuego");
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
