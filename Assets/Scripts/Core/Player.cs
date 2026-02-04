public enum MarioStatus { small, big, fire }
public class Player
{
    //A ESTO SE PUEDE ACCEDER DESDE CUALQUIER LADO A TRAVES DEL MAIN.PLAYER, PERO NO CAMBIARLAS, NECESITAMOS LOS METODOS DE ABAJO
    public string Lives { get; private set; } 
    public string Coins { get; private set; }
    public string Points { get; private set; }

    public float TimeElapsed { get; private set; }

    public MarioStatus Status { get; private set; } = MarioStatus.small; //inicializamos el estado en small (predeterminado)

    public void ChangeStatus()
    {

    }

    public void CoinChange()
    {

    }

    public void LivesChange()
    {

    }

    public void PointsChange()
    {

    }
   
}
