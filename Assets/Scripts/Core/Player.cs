using System.Diagnostics;

public enum MarioStatus { small, big, fire }
public class Player
{
    //A ESTO SE PUEDE ACCEDER DESDE CUALQUIER LADO A TRAVES DEL MAIN.PLAYER, PERO NO CAMBIARLAS, NECESITAMOS LOS METODOS DE ABAJO
    public int Lives { get; private set; } 
    public int Coins { get; private set; }
    public int Points { get; private set; }

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

    public void CoinChange(int Coinvalue)
    {
        Coins += Coinvalue;

        //lanzamos el evento de cambio de monedas
        Main.CustomEvents.OnCoinsChange?.Invoke();
    }

    public void LivesChange(int CurrentLifes)
    {
        Lives += CurrentLifes;


        // Evitar valores negativos
        if (Lives < 0)
            Lives = 0;

        // Avisar al UI
        Main.CustomEvents.OnLivesChanged?.Invoke();

        // Si llega a 0 → Game Over
        if (Lives == 0)
        {
           Main.CustomEvents.OnGameOver?.Invoke();
        }

    }

    public void PointsChange(int CurrentPoints)
    {
        Points += CurrentPoints;
        Main.CustomEvents.OnPointsChanged?.Invoke(); //lanzamos el evento de cambio de puntos

    }

    //Método para cambiar las vidas iniciales dependiendo de la dificultad
    public void SetDifficulty(int difficulty)
    {
        // 0 = Fácil, 1 = Normal, 2 = Difícil
        switch (difficulty)
        {
            case 0:
                Lives = 5;
                
                break;

            case 1:
                Lives = 3;
                break;

            case 2:
                Lives = 1;
                break;

            default:
                Lives = 3;
                break;
        }

        // Actualizamos el UI al entrar al nivel
        Main.CustomEvents.OnLivesChanged?.Invoke();
    }



}
