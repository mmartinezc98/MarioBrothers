using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryLevel2 : MonoBehaviour
{
    
    private Vector2 downCheck;
    private bool marioCheck = false;

    public string SceneToLoad = "Level1_2";

    
    private void Update()
    {
        downCheck = InputManager2.InputSystemActions.Player.Movement.ReadValue<Vector2>();

        //si mario entra en el trigger y pulsa hacia abajo cargamos el nivel
        if (marioCheck && downCheck.y <-0.1f)
        {
            Main.CustomEvents.OnLevelChanged.Invoke();
            SceneManager.LoadScene(SceneToLoad);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {    

            marioCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            marioCheck = false;
        }
    }
}
