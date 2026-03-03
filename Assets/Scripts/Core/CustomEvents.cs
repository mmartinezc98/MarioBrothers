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
    public UnityEvent<MarioStatus> OnStatusChange = new UnityEvent<MarioStatus>(); //se le pasa el MarioStatus
    public UnityEvent OnPowerUpTaken = new UnityEvent();
    public UnityEvent OnLivesChanged = new UnityEvent();
    public UnityEvent OnGameOver = new UnityEvent();
    public UnityEvent OnLevelChanged = new UnityEvent();
    public UnityEvent OnPlayerDead = new UnityEvent();




}
