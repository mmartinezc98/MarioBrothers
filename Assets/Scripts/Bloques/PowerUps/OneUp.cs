using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUp : PowerUpsMain
{
    public override void ApplyPowerUp()
    {
        // Sumar una vida a Mario
        Main.Player.AddLifes(1);

        // Sonido de 1UP
        Main.AudManager.PlaySound(Main.SoundLibrary.oneUp);

        // Destruir el objeto
        Destroy(gameObject);
    }

}
