using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class InicializerScene1 : MonoBehaviour //PARA INICIALIZAR TODO LO NECESARIO EN LA ESCENA
{
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private SoundLibrary soundLibrary;

    // referencia al  popup de puntos
    [SerializeField] private GameObject pointsPopupPrefab;

    private void Awake()
    {
        
        // Asignar el SoundLibrary al Main
        Main.SoundLibrary = soundLibrary;

        // Inicializamos el spawner de popups con el prefab asignado en el Inspector
        PointspopupSpawner.Init(pointsPopupPrefab);

        InputManager2.InputSystemActions.Player.Disable();
        //aseguramos que el panel este desactivado
        if (blackPanel != null)
        {
            blackPanel.SetActive(false);
        }
       
        //Main.CustomEvents.OnLivesChanged.AddListener(ShowBlackScreen);
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
        Main.AudManager.StopMusic();

        blackPanel.SetActive(true);

        yield return new WaitForSeconds(3f);

        blackPanel.SetActive(false);

        InputManager2.SwitchMap(InputManager2.InputSystemActions.Player); //inicializamos el input manager de los controles de mario
        Main.AudManager.PlayMusic(Main.SoundLibrary.groundLevel);

    }
}
