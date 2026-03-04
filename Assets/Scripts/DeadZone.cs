using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour //la usamos para destruir los enemigos cuando caen y para detectar cuando cae mari,matarlo, spawnearlo y cargar el nivel
{
    private void OnTriggerEnter2D(Collider2D collision) //comprobamos la colision
    {
        PlayerController mario = collision.gameObject.GetComponent<PlayerController>();

        if (mario != null) //si es mario destruimos el objeto
        {
            //restamos una ida a mario
            Main.Player.RestLifes(1);

            //invocamos el metodo de cambio de vidas
            Main.CustomEvents.OnLivesChanged.Invoke();

            Destroy(mario.gameObject);
            
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
