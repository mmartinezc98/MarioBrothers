using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlant : PowerUpsMain
{
    public override void ApplyPowerUp()
    {
        Main.CustomEvents.OnPowerUpTaken.Invoke();
    }
}
