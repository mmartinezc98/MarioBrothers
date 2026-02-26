using UnityEngine;

public static class Main
{
    public static I18n I18n;
    public static CustomEvents CustomEvents;
    public static Config Config;
    public static Player Player;

    //ultimo checkpoint guardado
    public static CheckPointEnum LastCheckPoint; //para guardar el ultimo checkpoint que hemos visitado

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] //hace que antes de que cargue la escena se ejecute el Start, creando todas las instancias
    public static void Start()
    {
        CustomEvents = new CustomEvents();
        I18n = new I18n();
        Player = new Player();

        //establecemos el checkpoint inicial (enum de checpoint spawn)
        LastCheckPoint = CheckPointEnum.Spawn; // checkpoint inicial


    }


}
