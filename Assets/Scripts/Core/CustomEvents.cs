using UnityEngine.Events;

public class CustomEvents
{
    //Generales
    public UnityEvent OnLanguageChanged = new UnityEvent();

    //Juegos
    public UnityEvent OnPausedGame = new UnityEvent();
    public UnityEvent OnResumeGame = new UnityEvent();
    public UnityEvent OnPointsChanged = new UnityEvent();

}
