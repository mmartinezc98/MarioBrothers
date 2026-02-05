using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    private void Awake()
    {
       
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
        Main.Player.ChangeStatus(MarioStatus.small);
        

        Debug.Log("Mario es pequeño");
    }

    public void SetBig() //cambia el estado a grande
    {
        Main.Player.ChangeStatus(MarioStatus.big);
        
        Debug.Log("Mario es grande");
    }

    public void SetFire() //cambia el estado a fuego
    {
        Main.Player.ChangeStatus(MarioStatus.fire);
       
        Debug.Log("Mario es de fuego");
    }
}
