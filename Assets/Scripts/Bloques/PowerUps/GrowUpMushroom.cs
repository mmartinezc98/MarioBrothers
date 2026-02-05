using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mushroom : PowerUpsMain
{
    public override void ApplyPowerUp()
    {
        Main.CustomEvents.OnPowerUpTaken.Invoke();

    }
}