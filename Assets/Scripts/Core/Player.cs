public enum MarioStatus { small, big, fire }
public class Player
{
    //A ESTO SE PUEDE ACCEDER DESDE CUALQUIER LADO A TRAVES DEL MAIN.PLAYER, PERO NO CAMBIARLAS, NECESITAMOS LOS METODOS DE ABAJO
    public string Lives { get; private set; } 
    public string Coins { get; private set; }
    public string Points { get; private set; }

    public float TimeElapsed { get; private set; }

    public MarioStatus Status { get; private set; } = MarioStatus.small; //inicializamos el estado en small (predeterminado)

    public void ChangeStatus(MarioStatus marioStatus)
    {
        switch (marioStatus) {  //cambiar los estados de mario

            case MarioStatus.small:
                Status = MarioStatus.small;
                break;
            
            case MarioStatus.big:
                Status = MarioStatus.big; 
                break;

            case MarioStatus.fire:
                Status = MarioStatus.fire;
                break;
                
        }
        Main.CustomEvents.OnStatusChange?.Invoke(marioStatus);
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
