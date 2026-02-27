using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda2 : MonoBehaviour
{
    private int points = 200;   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobamos si el objeto que entra es Mario
        // Asegúrate de que Mario tenga el tag "Player"
        if (collision.CompareTag("Player"))
        {
            //sumamos los puntos al contador
            Main.Player.PointsChange(points);
            Debug.Log(points);

            //sumamos una moneda al contador de monedas
            Main.Player.CoinChange(1);

            // Reproduce un sonido si quieres (opcional)
            // AudioSource.PlayClipAtPoint(coinSound, transform.position);

           

            // O destrúyela si prefieres:
            Destroy(gameObject);
        }
    }

}
