using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBricks : BlockBase
{
    private MarioStatus status; //para guardar el estado de mario

    private void Update()
    {
        status = Main.Player.Status; //Actualizamos el estado de mario por si cambia
    }
    protected override void OnHit(GameObject hitter)
    {
        
        if (status == MarioStatus.big || status == MarioStatus.fire) //si el estado es grando o de fuego se rompe el bloque
        {
            Main.AudManager.PlaySound(Main.SoundLibrary.brickbreak);
            BreakBlock();
        }
        else //si es peequeño hacemos solo el bump
        {
            Main.AudManager.PlaySound(Main.SoundLibrary.brickbump);
            state = BlockState.Idle;
            OnBecomeUsed();
        }

    }

    private void BreakBlock()//destruimos el bloque
    {
        state = BlockState.Broken;
        
        Destroy(gameObject);
    }


}
