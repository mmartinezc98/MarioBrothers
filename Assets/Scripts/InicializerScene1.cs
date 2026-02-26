using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class InicializerScene1 : MonoBehaviour //PARA INICIALIZAR TODO LO NECESARIO EN LA ESCENA
{
    [SerializeField] private GameObject blackPanel;
    
    private void Awake()
    {
        InputManager2.SwitchMap(InputManager2.InputSystemActions.Player); //inicializamos el input manager de los controles de mario

        //aseguramos que el panel este desactivado
        if(blackPanel != null)
        {
            blackPanel.SetActive(false);
        }
    }

    private void Start()
    {
        
        ShowBlackScreen();
    }

    public void ShowBlackScreen()
    {
        StartCoroutine(BlackScreenTimer());
    }

    private IEnumerator BlackScreenTimer()
    {
       blackPanel.SetActive(true);

        yield return new WaitForSeconds(3f);

        blackPanel.SetActive(false);
    }
}
