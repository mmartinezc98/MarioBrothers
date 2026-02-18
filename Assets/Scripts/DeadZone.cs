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
           // mario.Death(); //llamamos al metodo de morir de mario (player Controller)
            Destroy(mario.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
