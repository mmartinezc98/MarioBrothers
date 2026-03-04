using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieActivator : MonoBehaviour
{
    // El enemigo o grupo de enemigos a activar
    [SerializeField] private GameObject[] enemiesToActivate;

    private void Awake()
    {
        // Desactivamos los enemigos al inicio
        foreach (var enemy in enemiesToActivate)
            enemy.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Activamos todos los enemigos asignados
            foreach (var enemy in enemiesToActivate)
                enemy.SetActive(true);

            // Destruimos el trigger para que no vuelva a activarse
            Destroy(gameObject);
        }
    }
}
