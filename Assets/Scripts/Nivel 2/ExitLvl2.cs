using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLvl2 : MonoBehaviour
{
    private Vector2 rightCheck;
    private bool marioCheck = false;

    public string SceneToLoad = "Level1_1";
    

    // Update is called once per frame
    void Update()
    {
        rightCheck = InputManager2.InputSystemActions.Player.Movement.ReadValue<Vector2>();

        //si mario entra en el trigger y pulsa hacia abajo cargamos el nivel
        if (marioCheck && rightCheck.x > 0.1f)
        {
            Main.AudManager.PlaySound(Main.SoundLibrary.pipeDown);
            Main.LastCheckPoint = CheckPointEnum.Exitlvl2;
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
