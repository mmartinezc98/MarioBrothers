using UnityEngine.Events;

public class CustomEvents
{
    //Generales
    public UnityEvent OnLanguageChanged = new UnityEvent();

    //UI
    public UnityEvent OnPausedGame = new UnityEvent();
    public UnityEvent OnResumeGame = new UnityEvent();

    //MARIO
    public UnityEvent OnPointsChanged = new UnityEvent();
    public UnityEvent OnDamageTaken = new UnityEvent();
    public UnityEvent OnCoinsChange = new UnityEvent();
    public UnityEvent OnStatusChange = new UnityEvent();
    public UnityEvent OnPowerUpTaken = new UnityEvent();


}
