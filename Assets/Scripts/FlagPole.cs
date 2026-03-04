using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagPole : MonoBehaviour
{
    [SerializeField] private string nextScene = "PantallaInicio";

    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (levelCompleted) return;
        if (!other.CompareTag("Player")) return;

        levelCompleted = true;
        StartCoroutine(LevelCompleteRoutine(other.gameObject));
    }

    private System.Collections.IEnumerator LevelCompleteRoutine(GameObject mario)
    {
        // 1. Parar música normal
        Main.AudManager.StopMusic();

        // 2. Sonido de bandera
        Main.AudManager.PlaySound(Main.SoundLibrary.stageClear);

        // 4. Desactivar control del jugador
        mario.GetComponent<PlayerController>().enabled = false;

        // 5. Esperar animación
        yield return new WaitForSeconds(2f);

        // 6. Guardar la partida
        SaveSystem.Save(Main.Player.Points);

        // 7. Cargar siguiente escena
        SceneManager.LoadScene(nextScene);
    }

}
