using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]public GameObject gameOverUI;
    public float delayBeforeReturn = 6f;
    private void Awake()
    {
        Main.CustomEvents.OnGameOver?.AddListener(HandleGameOver);
       
    }


    void HandleGameOver()
    {
        StartCoroutine(GameOverRoutine());
    }


   
    IEnumerator GameOverRoutine()
    {
        Main.AudManager.PlaySound(Main.SoundLibrary.gameOver);

         Time.timeScale = 0f;
         gameOverUI.SetActive(true);

         yield return new WaitForSecondsRealtime(delayBeforeReturn);

         Time.timeScale = 1f;
         SceneManager.LoadScene("PantallaInicio");

    }

}
