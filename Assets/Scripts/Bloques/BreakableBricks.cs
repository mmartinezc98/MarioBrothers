using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBricks : BlockBase
{
    MarioStatus status = Main.Player.Status;
    protected override void OnHit(GameObject hitter)
    {
        
        if (status == MarioStatus.big || status == MarioStatus.fire)
        {
            BreakBlock();
        }
        else
        {
            // Mario pequeño → solo bump
            state = BlockState.Idle;
            OnBecomeUsed();
        }

    }

    private void BreakBlock()
    {
        state = BlockState.Broken;


        //destruimos el bloque
        Destroy(gameObject);
    }


}
